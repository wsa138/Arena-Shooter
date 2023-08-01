using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 3f;
    [SerializeField] float firingRate = 1f;
    [SerializeField] Transform gunOne;
    [SerializeField] Transform gunTwo;

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

            // Wait 1 second before spawning next set
            yield return new WaitForSeconds(firingRate);
        }
    }




}
