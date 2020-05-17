using System;
using System.Collections.Generic;
using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Extensions;
using EcsRx.Infrastructure.Plugins;
using EcsRx.Systems;
using MisfitLabs.EcsRx.Unity.Authoring.Systems;

namespace MisfitLabs.EcsRx.Unity.Authoring
{
    public class UnityAuthoringPlugin : IEcsRxPlugin
    {
        public string Name => "Unity Authoring Plugin";
        public Version Version => new Version(1, 0, 0);

        public void SetupDependencies(IDependencyContainer container)
        {
            container.Bind<ConvertToEntitySystem>();
        }

        public IEnumerable<ISystem> GetSystemsForRegistration(IDependencyContainer container)
        {
            return new List<ISystem>
            {
                container.Resolve<ConvertToEntitySystem>()
            };
        }
    }
}
