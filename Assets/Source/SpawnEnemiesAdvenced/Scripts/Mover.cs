using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private Transform _target;

        private void Update()
        {
            if (_target != null)
                MoveToTarget(); 
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void MoveToTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
    }
}

