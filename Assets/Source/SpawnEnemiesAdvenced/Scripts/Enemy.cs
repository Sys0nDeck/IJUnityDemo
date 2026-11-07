using System;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(Rotator))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _id;

        private Mover _mover;
        private Rotator _rotator;

        public event Action<Enemy> EnemyDead;

        public int Id => _id;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _rotator = GetComponent<Rotator>();
        }

        public void Init(Target target)
        {
            _mover.SetTarget(target.transform);
            _rotator.SetTarget(target.transform);
        }

        public void Die()
        {
            EnemyDead?.Invoke(this);
        }
    }
}

