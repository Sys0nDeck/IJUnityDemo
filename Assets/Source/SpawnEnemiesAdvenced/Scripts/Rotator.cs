using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class Rotator : MonoBehaviour
    {
        private Transform _targetPosition;

        private void Update()
        {
            RotateOnTarget();
        }

        public void SetTarget(Transform target)
        {
            _targetPosition = target;
        }

        private void RotateOnTarget()
        {
            transform.LookAt(_targetPosition);
        }
    }
}

