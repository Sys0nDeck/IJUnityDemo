using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace SpawnEnemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private SpawnPointProvider _spawnPointProvider;
        [SerializeField] private Vector3 _enemyDirection;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private int _poolCapacity = 5;
        [SerializeField] private int _poolMaxSize = 15;

        private ObjectPool<Enemy> _enemyPool;
        private Coroutine _coroutine;

        private void Awake()
        {
            _enemyPool = new ObjectPool<Enemy>(
                createFunc: () => CreateEnemy(),
                actionOnGet: (enemy) => OnEnemyGet(enemy),
                actionOnRelease: (enemy) => OnEnemyRelease(enemy),
                actionOnDestroy: (enemy) => Destroy(enemy),
                collectionCheck: true,
                defaultCapacity: _poolCapacity,
                maxSize: _poolMaxSize
                );
        }

        private void Start()
        {
            _coroutine = StartCoroutine(SpawnEnemy(_spawnDelay));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + GetDirection());
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.3f);
        }

        private Enemy CreateEnemy()
        {
            var newEnemy = Instantiate(_prefab);
            newEnemy.gameObject.SetActive(false);
            return newEnemy;
        }

        private void OnEnemyGet(Enemy enemy)
        {
            enemy.gameObject.transform.position = _spawnPointProvider.GetRandomSpawnPoint();
            enemy.Init(GetDirection());
            enemy.gameObject.SetActive(true);
            enemy.OnDead += ReturnEnemyInPool;
        }

        private void OnEnemyRelease(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            enemy.OnDead -= ReturnEnemyInPool;
        }

        private void ReturnEnemyInPool(Enemy enemy)
            => _enemyPool.Release(enemy);

        private Vector3 GetDirection()
            => _enemyDirection.normalized;

        private IEnumerator SpawnEnemy(float delay)
        {
            var time = new WaitForSecondsRealtime(delay);

            while (true)
            {
                yield return time;
                _enemyPool.Get();
            }
        }
    }
}

