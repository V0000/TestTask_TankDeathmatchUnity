using UnityEngine;

namespace Controllers
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target; 
        [SerializeField] private float followSpeed = 5f; 
        [SerializeField] private float rotationSpeed = 2f;

        private Vector3 offset;
        private Vector3 desiredPosition; // Желаемая позиция камеры

        private void Start()
        {
            offset = transform.position - target.position; // Рассчитываем смещение камеры в начале сцены
        }
        private void Update()
        {
            desiredPosition = target.position + target.forward * offset.z + target.up * offset.y;

            // Плавно перемещаем камеру к желаемой позиции
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            // Выполняем поворот камеры вокруг целевого объекта
            Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
