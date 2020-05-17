using EcsRx.Entities;
using MisfitLabs.EcsRx.Unity.Authoring.Systems;

namespace MisfitLabs.EcsRx.Unity.Authoring
{
    public interface IComponentConversion
    {
        void Convert(IEntity entity, ConvertToEntitySystem conversionSystem);
    }
}
