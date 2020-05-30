using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace MisfitLabs.EcsRx.Unity.Authoring.Systems
{
    public class ConvertToEntitySystemPlayModeTest
    {
        [UnityTest]
        public IEnumerator Test_Blah()
        {
            var gameObject = new GameObject("ConvertToEntity for Test");

            yield return new WaitForSeconds(0.1f);
        }
    }
}
