using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    [RequireComponent(typeof(Collider))]
    public class EnemyKiller : MonoBehaviour
    {
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
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.Die();
            }
        }
    }
}


