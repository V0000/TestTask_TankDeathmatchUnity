using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Monsters
{
    public class MonsterHealth : MonoBehaviour
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
            if (_currentHealth  <= 0)
            {
                Die();
            }
        }
    
        private void Die()
        {
            OnDeath?.Invoke(gameObject);
            Destroy(gameObject);
        }
    
    }
}
