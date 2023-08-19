using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;


    private void Start()
    {
        scoreText.text = "Score: " + ScoreManager.score.ToString();
    }

}
