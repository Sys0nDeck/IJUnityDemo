using UnityEngine;

namespace SpawnEnemies
{
    [RequireComponent(typeof(Collider))]
    public class DeadZone : MonoBehaviour
    {
        [SerializeField] private float _width = 30f;
        [SerializeField] private float _length = 30f;

        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void Start()
        {
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Enemy>(out var component))
            {
                component.Die();
            }
        }

        private void OnDrawGizmos()
        {
            var size = new Vector3(_width, 0f, _length);
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, size);
        }
    }
}

