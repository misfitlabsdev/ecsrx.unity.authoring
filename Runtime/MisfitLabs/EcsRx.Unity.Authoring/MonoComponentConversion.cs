using EcsRx.Entities;
using MisfitLabs.EcsRx.Unity.Authoring.Systems;
using UnityEngine;

namespace MisfitLabs.EcsRx.Unity.Authoring
{
    [RequireComponent(typeof(ConvertToEntity))]
    public abstract class MonoComponentConversion : MonoBehaviour, IComponentConversion
    {
        public abstract void Convert(IEntity entity, ConvertToEntitySystem conversionSystem);
    }
}
