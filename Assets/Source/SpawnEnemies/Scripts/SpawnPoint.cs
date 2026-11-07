using UnityEngine;

namespace SpawnEnemies
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private float _gizmosSphereRadius = 2f;

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _gizmosSphereRadius);
        }
    }
}


