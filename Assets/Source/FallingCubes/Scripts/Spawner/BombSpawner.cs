using UnityEngine;

namespace FallingCubes
{
    public class BombSpawner : Spawner<Bomb>
    {
        public void SetBomb(Vector3 position)
        {
            var bomb = Pool.Get();
            bomb.transform.position = position;
            bomb.gameObject.SetActive(true);
        }

        protected override void PoolGet(Bomb entity)
        {
            entity.Init(Random.Range(MinLifeTime, MaxLifeTime));
            entity.Exploded += HideBomb;
            base.PoolGet(entity);
        }

        protected override void PoolRelease(Bomb entity)
        {
            entity.Exploded -= HideBomb;
            base.PoolRelease(entity);
        }

        private void HideBomb(Bomb bomb)
        {
            Pool.Release(bomb);
        }
    }
}

