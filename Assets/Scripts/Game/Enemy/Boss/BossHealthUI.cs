using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    [SerializeField] private FinalFightHealth healthController;
    private int maxHealth;
    public Image healthBarImage;

    private void Start()
    {
        maxHealth = healthController.health;
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float normalizedHealth = (float)healthController.health / maxHealth; // Normalize health to 0-1 range
        healthBarImage.fillAmount = normalizedHealth; // Update fill amount of the health bar image
    }
}
