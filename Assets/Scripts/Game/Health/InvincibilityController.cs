using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController _healthController;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
    }

    // When taking damage, set invincibility to true, wait duration, set back to false.
    // Uses coroutine(Have code that executes accross multiple frames)
    public void StartInvincibility(float invincibilityDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)
    {
        _healthController.IsInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        _healthController.IsInvincible = false;
    }


}
