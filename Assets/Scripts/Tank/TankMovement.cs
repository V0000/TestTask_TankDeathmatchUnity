using UnityEngine;

namespace Tank
{
    public class TankMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float rotationSpeed = 100f;
        [SerializeField] private float smoothTime = 0.1f;

        private Rigidbody _tankRigidbody;
        private float _moveVelocity;

        private void Awake()
        {
            _tankRigidbody = GetComponent<Rigidbody>();
            _tankRigidbody.freezeRotation = true;
        }

        private void Update()
        {
            float moveInput = Input.GetAxis("Vertical");

            SmoothMoveTank(moveInput);
            RotateTank();
        }

        private void SmoothMoveTank(float input)
        {
            float targetVelocity = input * speed;
            _moveVelocity = Mathf.SmoothDamp(_moveVelocity, targetVelocity, ref _moveVelocity, smoothTime);

            Vector3 movement = transform.forward * (_moveVelocity * Time.deltaTime);
            _tankRigidbody.MovePosition(_tankRigidbody.position + movement);
        }

        private void RotateTank()
        {
            float rotationInput = Input.GetAxis("Horizontal");
            float rotation = rotationInput * rotationSpeed * Time.deltaTime;
            Quaternion deltaRotation = Quaternion.Euler(0f, rotation, 0f);
            _tankRigidbody.MoveRotation(_tankRigidbody.rotation * deltaRotation);
        }
    }
}