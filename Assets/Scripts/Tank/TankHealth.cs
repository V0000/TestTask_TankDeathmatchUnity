using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tank
{
    public class TankHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100; 
        [SerializeField, Range(0,1)] private float defense = 0.9f;
        private float _currentHealth; 
        public event Action<GameObject> OnDeath;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage * defense;
            Debug.Log(_currentHealth);
            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            OnDeath?.Invoke(gameObject);
            gameObject.SetActive(false);
        }
    }
}
