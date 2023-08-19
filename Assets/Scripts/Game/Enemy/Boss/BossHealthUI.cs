using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealthUI : MonoBehaviour
{
    [SerializeField] private FinalFightHealth healthController;
    private int maxHealth;
    public Image healthBarImage;
    private bool endIt = false;
    private bool pause = false;

    private void Start()
    {
        maxHealth = healthController.health;
    }

    private void Update()
    {
        if (endIt == true)
        {
            Invoke("MoveToEndScene", 3f);
            endIt = false;
            pause = true;
        }

        if (pause == true)
        {
            return;
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float normalizedHealth = (float)healthController.health / maxHealth; // Normalize health to 0-1 range
        healthBarImage.fillAmount = normalizedHealth; // Update fill amount of the health bar image
        if (healthController.health <= 0)
        {
            endIt = true;
        }
    }

    private void MoveToEndScene()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
