using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalFightHealth : MonoBehaviour
{
    [SerializeField] public int health = 100;
    [SerializeField] ParticleSystem explosionPrefab;



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
        // Implement death behavior
        ParticleSystem explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosion.Play();
        Destroy(explosion.gameObject, explosion.main.duration);

        Destroy(gameObject);

    }



}
