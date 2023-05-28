using UnityEngine;

namespace Monsters
{
    public class MonsterMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;
        private Transform _target;
        public Transform Target
        {
            set => _target = value;
        }
        
        private void Update()
        {
            if (_target != null)
            {
                // Вычисляем направление к цели
                Vector3 direction = _target.position - transform.position;
                direction.Normalize();
                Vector3 newPosition = transform.position + direction * movementSpeed * Time.deltaTime;
                
                transform.position = newPosition;
            }
        }
    }
}