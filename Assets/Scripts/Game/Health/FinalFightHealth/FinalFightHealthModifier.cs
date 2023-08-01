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
        FinalFightHealth otherHealth = collision.GetComponent<FinalFightHealth>();
        if (otherHealth != null)
        {
            otherHealth.DecreaseHealth(damageAmount);
        }

        DestroyOnCollision destroyScript = gameObject.GetComponent<DestroyOnCollision>();
        destroyScript.DestroyGameObject();
    }
}
