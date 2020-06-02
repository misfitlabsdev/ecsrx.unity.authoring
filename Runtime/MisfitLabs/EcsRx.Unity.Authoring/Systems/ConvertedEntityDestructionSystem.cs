using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.Plugins.ReactiveSystems.Systems;
using EcsRx.Plugins.Views.Components;
using EcsRx.Unity.Extensions;
using MisfitLabs.EcsRx.Unity.Authoring.Components;
using UnityEngine;

namespace MisfitLabs.EcsRx.Unity.Authoring.Systems
{
    public class ConvertedEntityDestructionSystem : ITeardownSystem
    {
        public IGroup Group { get; } = new Group(typeof(ViewComponent), typeof(ConvertedComponent));

        public void Teardown(IEntity entity)
        {
            var gameObject = entity.GetGameObject();
            Object.Destroy(gameObject);
        }
    }
}
