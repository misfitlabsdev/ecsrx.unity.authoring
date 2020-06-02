using EcsRx.Collections.Database;
using NSubstitute;
using NSubstitute.ClearExtensions;
using NUnit.Framework;

namespace MisfitLabs.EcsRx.Unity.Authoring.Systems
{
    public class ConvertToEntitySystemTest
    {
        private readonly IEntityDatabase _entityDatabase = Substitute.For<IEntityDatabase>();

        [SetUp]
        public void Setup()
        {
            _entityDatabase.ClearSubstitute();
        }

        [Test]
        public void Test_Group_Is_Empty()
        {
            var system = new ConvertToEntitySystem(_entityDatabase);

            Assert.That(system.Group.RequiredComponents, Is.Empty);
            Assert.That(system.Group.ExcludedComponents, Is.Empty);
        }
    }
}
