using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipInteriorCheckpointController : MonoBehaviour
{
    // If player collides with ship, Delay 5 seconds, change ship color, then load next scene.
    public string bossBattleSceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            SceneManager.LoadScene(bossBattleSceneName);
        }
    }
}
