using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySettings : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    private void Awake() {
        _currentHealth = _maxHealth;
    }

    public void ReceiveDamage(int d)
    {
        _currentHealth -= d;

        if (_currentHealth < 1)
            Die();
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
