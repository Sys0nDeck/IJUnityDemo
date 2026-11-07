using System;
using UnityEngine;
using UnityEngine.Pool;

namespace FallingCubes
{
    public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected float MinLifeTime = 2;
        [SerializeField] protected float MaxLifeTime = 5;

        [SerializeField] private T _prefab;
        [SerializeField] private int _poolCapacity = 5;
        [SerializeField] private int _poolMaxSize = 10;

        protected ObjectPool<T> Pool;

        private int _spawnEntitiesCount = 0;
        private int _createEntitiesCount = 0;

        public event Action<int> SpawnEntitiesChanged;
        public event Action<int> CreateEntitiesChanged;
        public event Action<int> ActiveEntitiesChanged;

        private void Awake()
        {
            Pool = new ObjectPool<T>(
                createFunc: () => PoolCreate(),
                actionOnGet: (entity) => PoolGet(entity),
                actionOnRelease: (entity) => PoolRelease(entity),
                actionOnDestroy: (entity) => PoolDestroy(entity),
                collectionCheck: true,
                defaultCapacity: _poolCapacity,
                maxSize: _poolMaxSize);
        }

        protected virtual T PoolCreate()
        {
            T entity = Instantiate(_prefab);
            entity.gameObject.SetActive(false);
            NotifyEvent(CreateEntitiesChanged, ++_createEntitiesCount);
            return entity;
        }

        protected virtual void PoolDestroy(T entity)
        {
            Destroy(entity);
        }

        protected virtual void PoolGet(T entity)
        {
            entity.gameObject.SetActive(true);
            NotifyEvent(SpawnEntitiesChanged, ++_spawnEntitiesCount);
            NotifyEvent(ActiveEntitiesChanged, Pool.CountActive);
        }

        protected virtual void PoolRelease(T entity)
        {
            entity.gameObject.SetActive(false);
            NotifyEvent(ActiveEntitiesChanged, Pool.CountActive);
        }

        private void NotifyEvent(Action<int> action, int value)
        {
            action?.Invoke(value);
        }
    }
}

