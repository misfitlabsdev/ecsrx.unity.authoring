using System.Collections.Generic;
using EcsRx.Collections.Database;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Groups.Observable;
using EcsRx.Plugins.Views.Components;
using EcsRx.Systems;
using EcsRx.Unity.MonoBehaviours;
using MisfitLabs.EcsRx.Unity.Authoring.Components;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace MisfitLabs.EcsRx.Unity.Authoring.Systems
{
    public class ConvertToEntitySystem : IManualSystem
    {
        private readonly IEntityDatabase _entityDatabase;

        private readonly List<ConvertToEntity> _entitiesToConvert = new List<ConvertToEntity>();
        private readonly Dictionary<GameObject, IEntity> _entitiesByGameObject = new Dictionary<GameObject, IEntity>();

        public IGroup Group { get; } = new EmptyGroup();

        public ConvertToEntitySystem(IEntityDatabase entityDatabase)
        {
            _entityDatabase = entityDatabase;
        }

        public void StartSystem(IObservableGroup observableGroup)
        {
            // TODO: Test/confirm that conversions on prefabs and other objects after the scene is already running
            //  still convert correctly.
            Observable.EveryUpdate()
                .Subscribe(x => Convert());
        }

        public void StopSystem(IObservableGroup observableGroup)
        {
        }

        public void AddToBeConverted(ConvertToEntity convertToEntity)
        {
            _entitiesToConvert.Add(convertToEntity);
        }

        /// <summary>
        /// Returns the Entity that corresponds to the specified GameObject; either finding it or performing the
        /// conversion on demand if it has not already been converted.
        /// </summary>
        public IEntity GetPrimaryEntity(GameObject gameObject)
        {
            _entitiesByGameObject.TryGetValue(gameObject, out var entity);
            if (entity != null) return entity;

            var toConvert = gameObject.GetComponent<ConvertToEntity>();
            if (toConvert == null) return null;

            return ConvertGameObject(toConvert);
        }

        private void Convert()
        {
            if (_entitiesToConvert.Count == 0) return;

            foreach (var toConvert in _entitiesToConvert)
            {
                if (!toConvert.gameObject.activeInHierarchy || !toConvert.gameObject.activeSelf)
                {
                    // TODO: Instead of returning here maybe it's better to make sure only active objects get added to convert.
                    continue;
                }

                if (toConvert.IsConverted) continue;

                // TODO: Consider allowing use of different collections.
                ConvertGameObject(toConvert);

                toConvert.IsConverted = true;
            }

            foreach (var toDestroy in _entitiesToConvert)
            {
                Object.Destroy(toDestroy);
            }

            _entitiesToConvert.Clear();
        }

        private IEntity ConvertGameObject(ConvertToEntity toConvert)
        {
            var gameObject = toConvert.gameObject;

            var entityCollection = _entityDatabase.GetCollection();
            var entity = entityCollection.CreateEntity();

            entity.AddComponents(
                new ViewComponent {View = gameObject, DestroyWithView = true},
                new ConvertedComponent());

            var entityBinding = gameObject.AddComponent<EntityView>();
            entityBinding.Entity = entity;
            entityBinding.EntityCollection = entityCollection;

            gameObject.OnDestroyAsObservable()
                .Subscribe(x =>
                {
                    entityBinding.EntityCollection.RemoveEntity(entity.Id);
                    _entitiesByGameObject.Remove(entityBinding.gameObject);
                });

            _entitiesByGameObject.Add(gameObject, entity);

            var componentConversions = new List<IComponentConversion>();
            gameObject.GetComponents(componentConversions);
            foreach (var conversion in componentConversions)
            {
                conversion.Convert(entity, this);
                Object.Destroy((Component) conversion);
            }

            toConvert.IsConverted = true;

            return entity;
        }
    }
}
