using EcsRx.Plugins.Views.Components;
using MisfitLabs.EcsRx.Unity.Authoring.Components;
using NUnit.Framework;

namespace MisfitLabs.EcsRx.Unity.Authoring.Systems
{
    public class ConvertedEntityDestructionSystemTest
    {
        [Test]
        public void Test_Group_Requires_ViewComponent()
        {
            var system = new ConvertedEntityDestructionSystem();

            Assert.That(system.Group.RequiredComponents, Contains.Item(typeof(ViewComponent)));
        }

        [Test]
        public void Test_Group_Requires_ConvertedComponent()
        {
            var system = new ConvertedEntityDestructionSystem();

            Assert.That(system.Group.RequiredComponents, Contains.Item(typeof(ConvertedComponent)));
        }
    }
}
