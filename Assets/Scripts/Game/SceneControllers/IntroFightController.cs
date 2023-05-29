using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroFightController : MonoBehaviour
{
    // Name of next scene to load
    public string nextSceneName;
    public GameObject bossPrefab;
    public Transform bossSpawnPoint;

    // Function to call when the current scene ends
    public void EndScene()
    {
        Debug.Log("Loading Next Scene Started");

        SpawnBoss();

        StartCoroutine(LoadNextSceneWithDelay());
    }


    private IEnumerator LoadNextSceneWithDelay()
    {
        // Wait 5 seconds
        yield return new WaitForSeconds(8f);

        // Load Scene
        SceneManager.LoadScene(nextSceneName);
        Debug.Log("Loading Next Scene Ended");
    }

    public void SpawnBoss()
    {
        // Instantiate the prefab at the current position with default rotation.
        Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);
    }

}
