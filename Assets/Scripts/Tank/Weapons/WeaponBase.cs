using Tank.Projectiles;
using UnityEngine;

namespace Tank.Weapons
{
    public class WeaponBase : MonoBehaviour, IWeapon
    {
        private GameObject _bullet;
        private BulletPool _bulletPool;
        
        private void Start()
        {
            _bulletPool = gameObject.GetComponent<BulletPool>();
        }
        
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }


        public virtual void Shoot()
        {
            _bullet = _bulletPool.GetBullet();

            if (_bullet != null)
            {
                _bullet.transform.position = transform.position;
                _bullet.transform.rotation = transform.rotation;

                BulletMovement bulletMovement = _bullet.GetComponent<BulletMovement>();
                bulletMovement.SetDirection(transform.forward);
            }
        }
        
        
    }
}