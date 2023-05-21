using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIManager : MonoBehaviour
{
    private TMP_Text scoreText; // Reference to the UI text element

    private void Start()
    {
        // Find the UI text element in the hierarchy
        scoreText = GetComponentInChildren<TMP_Text>();

        if (scoreText == null)
        {
            Debug.LogError("ScoreUIManager: Unable to find Text component.");
        }
    }

    private void Update()
    {
        if (scoreText != null)
        {
            // Update the score text with the current score value
            scoreText.text = "Score: " + ScoreManager.score.ToString();
        }        
    }
}
