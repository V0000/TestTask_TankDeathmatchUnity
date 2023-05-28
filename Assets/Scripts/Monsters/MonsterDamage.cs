using Tank;
using UnityEngine;

namespace Monsters
{
    public class MonsterDamage : MonoBehaviour
    {
        [SerializeField] private float damage = 10; 

        private void OnTriggerEnter(Collider other)
        {
            TankHealth tankHealth = other.GetComponent<TankHealth>();
            if (tankHealth != null)
            {
                tankHealth.TakeDamage(damage);
            }
        }
    }
}