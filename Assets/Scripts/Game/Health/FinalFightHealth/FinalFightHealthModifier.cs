using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFightHealthModifier : MonoBehaviour
{
    [SerializeField] int damageAmount = 10;
    [SerializeField] GameObject nonTargetObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(nonTargetObject.tag))
        {
            return;
        }

        if (collision.gameObject.CompareTag("BabyBossShip"))
        {
            Destroy(collision.gameObject);
            ScoreManager.score += 10;
        }

        if (collision.GetComponent<HealthController>())
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(damageAmount);
            return;

        }

        FinalFightHealth otherHealth = collision.GetComponent<FinalFightHealth>();
        if (otherHealth != null)
        {
            otherHealth.DecreaseHealth(damageAmount);
        }

        DestroyOnCollision destroyScript = gameObject.GetComponent<DestroyOnCollision>();
        destroyScript.DestroyGameObject();
    }
}
