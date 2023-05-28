using Monsters;
using UnityEngine;

namespace Tank.Projectiles
{
    public class BulletDamage : MonoBehaviour
    {
        [SerializeField] private int damage = 20; 

        private void OnTriggerEnter(Collider other)
        {
            MonsterHealth monsterHealth = other.GetComponent<MonsterHealth>();
            if (monsterHealth != null)
            {
                monsterHealth.TakeDamage(damage);
                gameObject.SetActive(false);;
            }
        }
    }
}