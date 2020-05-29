using System.Collections;
using EcsRx.Entities;
using EcsRx.Plugins.Views.Components;
using NSubstitute;
using NUnit.Framework;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.TestTools;

namespace MisfitLabs.EcsRx.Unity.Authoring.Systems
{
    public class ConvertedEntityDestructionSystemPlayModeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [UnityTest]
        public IEnumerator Test_Destroys_GameObject_On_Teardown()
        {
            var gameObject = new GameObject("EntityView For Test");

            var entity = Substitute.For<IEntity>();
            var viewComponent = new ViewComponent {View = gameObject};
            entity.GetComponent(typeof(ViewComponent)).Returns(viewComponent);

            var isGameObjectDestroyed = false;
            gameObject.OnDestroyAsObservable()
                .Subscribe(x => isGameObjectDestroyed = true);

            var system = new ConvertedEntityDestructionSystem();
            system.Teardown(entity);

            yield return new WaitForEndOfFrame();

            Assert.That(isGameObjectDestroyed, Is.True);
        }
    }
}
