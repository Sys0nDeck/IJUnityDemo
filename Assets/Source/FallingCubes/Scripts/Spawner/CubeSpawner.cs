using System.Collections;
using UnityEngine;

namespace FallingCubes
{
    public class CubeSpawner : Spawner<FallingCube>
    {
        [SerializeField] private SpawnField _spawnField;
        [SerializeField] private float _spawnDelay = 1f;
        [SerializeField] private BombSpawner _bombSpawner;

        private Coroutine _coroutine;

        private void Start()
        {
            _coroutine = StartCoroutine(Spawn());
        }

        protected override void PoolGet(FallingCube entity)
        {
            var obj = entity.gameObject;
            obj.transform.position = _spawnField.GetRandomPosition();
            entity.Init(Random.Range(MinLifeTime, MaxLifeTime + 1));
            entity.LifeEnded += HideCube;
            base.PoolGet(entity);
        }

        protected override void PoolRelease(FallingCube entity)
        {
            entity.LifeEnded -= HideCube;
            base.PoolRelease(entity);
        }

        private void HideCube(FallingCube cube)
        {
            Pool.Release(cube);
            _bombSpawner.SetBomb(cube.transform.position);
        }

        private IEnumerator Spawn()
        {
            var delay = new WaitForSecondsRealtime(_spawnDelay);

            while (true)
            {
                Pool.Get();
                yield return delay;
            }
        }
    }
}

