using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Target _target;
        [SerializeField] private float _gizmosSphereRadius = 2f;

        public Enemy GetPrefab => _prefab;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _gizmosSphereRadius);
        }

        public void InitEnemy(Enemy enemy)
        {
            enemy.transform.position = transform.position;
            enemy.Init(_target);
        }
    }
}


