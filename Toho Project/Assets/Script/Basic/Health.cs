using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour, IHealable
{
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private Animator _animator;
    private int _currentHealth;

    public event Action<float> HealthChanged;

    void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void ChangedHealth(int value)
    {
        _currentHealth += value;
        if (_currentHealth <= 0)
        {
            _animator.SetBool("Dead", true);
            Invoke("Death",4f);
        }
        else if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else
        {
            float _currentHealthFilled = (float)_currentHealth / _maxHealth;
            HealthChanged?.Invoke(_currentHealthFilled);
        }
    }
    private void Death()
    {
        HealthChanged?.Invoke(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
