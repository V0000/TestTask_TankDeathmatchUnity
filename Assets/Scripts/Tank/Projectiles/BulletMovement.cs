using UnityEngine;

namespace Tank.Projectiles
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private float spreadAngle = 0f;
        [SerializeField] private float speed = 5f;
        private float _lifeTime = 5f;
        private Vector3 _direction;


        public float LifeTime => _lifeTime;

        public void SetDirection(Vector3 direction)
        {
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);
            Quaternion spreadRotation = Quaternion.Euler(0f, randomAngle, 0f);
            _direction = spreadRotation * direction;
        }


        private void Update()
        {
            transform.position += _direction * (speed * Time.deltaTime);
        }
    }
}