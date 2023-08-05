using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private void OnDestroy()
    {
        ScoreManager.score += 1000;
        Debug.Log("You Win!");
    }
}
