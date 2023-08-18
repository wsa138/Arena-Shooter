using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFightHealth : MonoBehaviour
{
    [SerializeField] public int health = 100;

    private void Start()
    {
    }

    public void DecreaseHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
            Debug.Log("Destroyed");
        }
    }

    private void Die()
    {
        // implement death behavior
        Destroy(gameObject);
    }
}
