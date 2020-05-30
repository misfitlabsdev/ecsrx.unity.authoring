using System;
using System.Collections;
using EcsRx.Unity.MonoBehaviours;
using MisfitLabs.EcsRx.Unity.Authoring.MonoBehaviours;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace MisfitLabs.EcsRx.Unity.Authoring.Systems
{
    public class ConvertToEntitySystemPlayModeTest
    {
        private String _initialScenePath;

        [OneTimeSetUp]
        public void OnetimeSetup()
        {
            Debug.Log("Load Scene");
            _initialScenePath = SceneManager.GetActiveScene().path;
            SceneManager.LoadScene("PlayModeTestsScene");
        }

        [OneTimeTearDown]
        public void OnetimeTeardown()
        {
            SceneManager.LoadScene(_initialScenePath);
        }

        [UnityTest]
        public IEnumerator Test_Blah()
        {
            var gameObject = new GameObject("ConvertToEntity for Test");
            gameObject.AddComponent<ConvertToEntity>();
            gameObject.AddComponent<TestConvertible>();

            var convertToEntitySystem = new ConvertToEntitySystem();

            yield return new WaitForSeconds(0.1f);

            var entityView = gameObject.GetComponent<EntityView>();

            yield return new WaitForSeconds(10f);

            Assert.That(entityView, Is.Not.Null);
        }
    }
}
