using EcsRx.Entities;
using EcsRx.Extensions;
using MisfitLabs.EcsRx.Unity.Authoring.Components;
using MisfitLabs.EcsRx.Unity.Authoring.Systems;
using UnityEngine;

namespace MisfitLabs.EcsRx.Unity.Authoring.MonoBehaviours
{
    public class TestConvertible : MonoBehaviour, IComponentConversion
    {
        public void Convert(IEntity entity, ConvertToEntitySystem conversionSystem)
        {
            var testConversionComponent = new TestConversionComponent {ConvertedValue = "Hello World"};
            entity.AddComponents(testConversionComponent);
        }
    }
}
