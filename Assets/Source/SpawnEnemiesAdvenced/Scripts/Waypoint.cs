using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private Color _gizmosPointColor = Color.yellow;

        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmosPointColor;
            Gizmos.DrawSphere(transform.position, 0.1f);
        }
    }
}

