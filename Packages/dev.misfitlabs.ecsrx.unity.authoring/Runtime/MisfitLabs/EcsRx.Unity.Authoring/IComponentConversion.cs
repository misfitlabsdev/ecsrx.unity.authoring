using EcsRx.Entities;
using MisfitLabs.EcsRx.Unity.Authoring.Systems;

namespace MisfitLabs.EcsRx.Unity.Authoring
{
    /// <summary>
    /// A conversion for authoring MonoBehaviours to implement additional logic for converting fields from the
    /// GameObject to the corresponding Entity.
    ///
    /// When this is used on a GameObject that also has <see cref="ConvertToEntity"/>, the <see cref="Convert"/> will be
    /// called with the converted entity. The implementing MonaBehaviour can add additional components onto the entity
    /// or lookup related entities.
    /// </summary>
    public interface IComponentConversion
    {
        /// <summary>
        /// Converts the MonoBehaviour fields into Components and attaches them to the converted entity.
        /// </summary>
        void Convert(IEntity entity, ConvertToEntitySystem conversionSystem);
    }
}
