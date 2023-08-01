using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    private void OnDestroy()
    {
        Debug.Log("You lose...");

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
