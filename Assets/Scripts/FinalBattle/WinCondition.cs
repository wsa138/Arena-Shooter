using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private void OnDestroy()
    {
        Debug.Log("You Win!");
    }
}
