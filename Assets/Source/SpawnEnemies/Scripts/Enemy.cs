using System;
using UnityEngine;

namespace SpawnEnemies
{
    [RequireComponent(typeof(Movement))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Movement _movement;

        public event Action<Enemy> OnDead;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
        }

        public void Init(Vector3 direction)
        {
            _movement.Init(direction);
        }

        public void Die()
        {
            OnDead?.Invoke(this);
        }
    }
}

