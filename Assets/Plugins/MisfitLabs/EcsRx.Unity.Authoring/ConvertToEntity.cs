using MisfitLabs.EcsRx.Unity.Authoring.Systems;
using UnityEngine;
using Zenject;

namespace MisfitLabs.EcsRx.Unity.Authoring
{
    /// <summary>
    /// An MonoBehaviour that can be attached to a GameObject to hook it into the <see cref="ConvertToEntitySystem"/> to
    /// be automatically converted into an entity. Use <see cref="IComponentConversion"/> for customizing conversion
    /// of Editor defined fields into Components on the corresponding Entity.
    /// </summary>
    public class ConvertToEntity : MonoBehaviour
    {
        /// <summary>
        /// Returns true when the object has already been converted to an Entity.
        /// </summary>
        internal bool IsConverted { get; set; }

        [Inject]
        internal ConvertToEntitySystem ConvertToEntitySystem { get; private set; }

        [Inject]
        public void AddForConversion()
        {
            ConvertToEntitySystem.AddToBeConverted(this);
        }
    }
}
