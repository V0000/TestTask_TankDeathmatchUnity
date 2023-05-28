using System.Collections;
using System.Collections.Generic;
using Tank.Projectiles;
using UnityEngine;

namespace Tank.Weapons
{
    public class BulletPool : MonoBehaviour
    {
        public GameObject bulletPrefab;
        [Min(1)] public int poolSize = 10;
        private float _lifeTime = 5f;

        private List<GameObject> _bulletPool;
        private GameObject _parentObject;
        private GameObject _bullet;

        private void OnEnable()
        {
            if (_bulletPool != null)
            {
                foreach (GameObject bullet in _bulletPool)
                {
                    bullet.SetActive(false);
                }
            }
        }

        private void Start()
        {
            _parentObject = new GameObject(bulletPrefab.name + 's');

            _bulletPool = new List<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                _bullet = CreateBullet();
            }

            _lifeTime = _bulletPool[0].GetComponent<BulletMovement>().LifeTime;
        }

        public GameObject GetBullet()
        {
            foreach (GameObject bullet in _bulletPool)
            {
                if (!bullet.activeInHierarchy)
                {
                    bullet.SetActive(true);
                    StartCoroutine(DisableBullet(bullet));
                    return bullet;
                }
            }

            return CreateBullet();
        }

        private IEnumerator DisableBullet(GameObject bullet)
        {
            yield return new WaitForSeconds(_lifeTime);
            bullet.SetActive(false);
        }
        
        private GameObject CreateBullet()
        {
            _bullet = Instantiate(bulletPrefab, _parentObject.transform);
            _bullet.SetActive(false);
            _bulletPool.Add(_bullet);
            return _bullet;
        }
    }
}