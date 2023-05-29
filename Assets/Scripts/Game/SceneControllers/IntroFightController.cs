using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroFightController : MonoBehaviour
{
    // Name of next scene to load
    public string nextSceneName;

    // Function to call when the current scene ends
    public void EndScene()
    {
        Debug.Log("Loading Next Scene Started");
        StartCoroutine(LoadNextSceneWithDelay());
    }


    private IEnumerator LoadNextSceneWithDelay()
    {
        // Wait 5 seconds
        yield return new WaitForSeconds(5f);

        // Load Scene
        SceneManager.LoadScene(nextSceneName);
        Debug.Log("Loading Next Scene Ended");
    }

}
