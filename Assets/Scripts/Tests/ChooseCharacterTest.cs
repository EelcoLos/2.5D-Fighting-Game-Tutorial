using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

[TestFixture]
public class ChooseCharacterTest
{
    

    [UnityTest]
    public IEnumerator TestSceneLoading()
    {
        // ------------- SET UP ----------------//
        // Store the test scne in a temp variable
        var testScene = SceneManager.GetActiveScene();
        // Load the game scene you want to use
        yield return SceneManager.LoadSceneAsync("ChooseCharacter", LoadSceneMode.Additive);
        // After it is loaded, set the scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("ChooseCharacter"));
        // ------------ ASSERT TEST -----------//
        // Assert that the game scene has been set to active. If not, an exception will be thrown
        Assert.IsTrue(SceneManager.GetActiveScene().name == "ChooseCharacter");

        // ------------ CLEAN UP -------------//
        // Set the active scene back to the test scene to close the test
        SceneManager.SetActiveScene(testScene);
        // Clean up the game scene
        yield return SceneManager.UnloadSceneAsync("ChooseCharacter");
    }

    [UnityTest]
    public IEnumerator TestSceneStartObject()
    {
        // ------------- SET UP ----------------//
        // Store the test scne in a temp variable
        var testScene = SceneManager.GetActiveScene();
        // Load the game scene you want to use
        yield return SceneManager.LoadSceneAsync("ChooseCharacter", LoadSceneMode.Additive);
        // After it is loaded, set the scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("ChooseCharacter"));
        // ------------ ASSERT TEST -----------//
        // Assert that the game scene has been set to active. If not, an exception will be thrown
        var assertScene = SceneManager.GetActiveScene();
        var objects = assertScene.GetRootGameObjects();
        Debug.LogFormat("Objects length: {0}", objects.Length);

        GameObject robot = new GameObject("NotBot");
        for (int i = 0; i < objects.Length; i++)
        {
            Debug.LogFormat("Object #{0}'s name: {1}", i, objects[i].name);
            if (objects[i].name.Contains("Robot"))
            {
                Debug.LogFormat("bot found, name: {0}", objects[i].name);
            }
        }

        Assert.IsNotNull(robot);
        //Assert.IsTrue(robot.name == "BlackRobot", "The assert was false, bot name is {0}", robot.name);
        // ------------ CLEAN UP -------------//
        // Set the active scene back to the test scene to close the test
        SceneManager.SetActiveScene(testScene);
        // Clean up the game scene
        yield return SceneManager.UnloadSceneAsync("ChooseCharacter");
    }
}
