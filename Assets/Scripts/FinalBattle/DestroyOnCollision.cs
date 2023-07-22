using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}

