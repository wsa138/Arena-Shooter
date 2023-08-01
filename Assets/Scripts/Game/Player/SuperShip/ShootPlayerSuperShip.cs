using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootPlayerSuperShip : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 3f;
    [SerializeField] float firingRate = .2f;
    [SerializeField] GameObject gunOne;
    [SerializeField] GameObject gunTwo;

    private bool isFiring;

    Coroutine firingCoroutine;


    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }       
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance1 = Instantiate(projectilePrefab, gunOne.transform.position, Quaternion.identity);
            GameObject instance2 = Instantiate(projectilePrefab, gunTwo.transform.position, Quaternion.identity);

            Rigidbody2D bulletRB1 = instance1.GetComponent<Rigidbody2D>();
            Rigidbody2D bulletRB2 = instance2.GetComponent<Rigidbody2D>();

            bulletRB1.velocity = transform.up * projectileSpeed;
            bulletRB2.velocity = transform.up * projectileSpeed;

            Destroy(instance1, projectileLifetime);
            Destroy(instance2, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }

    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
}
