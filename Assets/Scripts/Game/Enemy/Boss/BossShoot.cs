using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 2f;
    [SerializeField] float firingRate = 1f;
    [SerializeField] Transform gunOne;
    [SerializeField] Transform gunTwo;
    [SerializeField] Transform bigGun;

    [SerializeField] GameObject projectilePrefab2;
    [SerializeField] float projectileSpeed2 = 10f;
    [SerializeField] float projectileLifetime2 = 5f;

    private void Start()
    {
        StartCoroutine(SpawnBullets());
    }

    private IEnumerator SpawnBullets()
    {
        while (true)
        {
            // Instantiate the bullet prefab at spawnPoint1 and spawnPoint2 positions
            GameObject bullet1 = Instantiate(projectilePrefab, gunOne.position, Quaternion.identity);
            GameObject bullet2 = Instantiate(projectilePrefab, gunTwo.position, Quaternion.identity);
            

            // Set bullet speed and lifetime
            bullet1.GetComponent<Rigidbody2D>().velocity = Vector2.down * projectileSpeed;
            bullet2.GetComponent<Rigidbody2D>().velocity = Vector2.down * projectileSpeed;
            

            // Destroy the bullets after the specified lifetime
            Destroy(bullet1, projectileLifetime);
            Destroy(bullet2, projectileLifetime);

            MaybeFireBig();

            // Wait 1 second before spawning next set
            yield return new WaitForSeconds(firingRate);
        }
    }

    private void MaybeFireBig()
    {
        // Generate a random number between 0 and 1 (inclusive)
        float randomValue = Random.Range(0f, 1f);

        // Set a threshold probability (e.g., 0.5 for 50% chance)
        float threshold = 0.3f;

        // Check if the random value is less than the threshold
        if (randomValue < threshold)
        {
            // Execute Debug.Log("Test") randomly
            GameObject bigBullet = Instantiate(projectilePrefab2, bigGun.position, Quaternion.identity);
            bigBullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * projectileSpeed2;
            Destroy(bigBullet, projectileLifetime2);
        }
    }




}
