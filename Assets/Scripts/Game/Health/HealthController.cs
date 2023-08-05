using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float _currentHealth;

    [SerializeField] private float _maximumHealth;

    private IntroFightController sceneController;
    public bool IsInvincible { get; set; }

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    // This is set in the editor.
    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public UnityEvent OnHealthChanged;

    private void Start()
    {
        sceneController = FindObjectOfType<IntroFightController>();
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        _currentHealth -= damageAmount;

        OnHealthChanged.Invoke();

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        // Call the OnDied event if health is 0.
        if (_currentHealth == 0)
        {
            OnDied.Invoke();
            Debug.Log("Captured!");
            if (SceneManager.GetActiveScene().name == "ArenaScene" || SceneManager.GetActiveScene().name == "BossBattle")
            {
                SceneManager.LoadScene("ArenaScene");
            }
            else
            {
                sceneController.EndScene();
            }            
        } 
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maximumHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;

        OnHealthChanged.Invoke();

        if (_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }
    }
}
