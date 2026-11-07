using UnityEngine;

namespace SpawnEnemies
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private Vector3 _movementDirection = Vector3.zero;

        private void OnEnable()
        {
            SetDirection(_movementDirection);
        }

        private void Update()
        {
            Move();
        }

        public void Init(Vector3 direction)
        {
            _movementDirection = direction;
        }

        private void Move()
            => transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        private void SetDirection(Vector3 direction)
            => transform.rotation = Quaternion.LookRotation(direction);
    }
}

