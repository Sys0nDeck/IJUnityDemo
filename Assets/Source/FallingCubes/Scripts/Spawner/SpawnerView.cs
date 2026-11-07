using UnityEngine;

namespace FallingCubes
{
    public abstract class SpawnerView<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private Spawner<T> _spawner;

        private void OnEnable()
        {
            _spawner.SpawnEntitiesChanged += OnSpawnEntitiesChanged;
            _spawner.CreateEntitiesChanged += OnCreateEntitiesChanged;
            _spawner.ActiveEntitiesChanged += OnActiveEntitiesChanged;
        }

        private void OnDisable()
        {
            _spawner.SpawnEntitiesChanged -= OnSpawnEntitiesChanged;
            _spawner.CreateEntitiesChanged -= OnCreateEntitiesChanged;
            _spawner.ActiveEntitiesChanged -= OnActiveEntitiesChanged;
        }

        protected abstract void OnCreateEntitiesChanged(int value);

        protected abstract void OnSpawnEntitiesChanged(int value);

        protected abstract void OnActiveEntitiesChanged(int value);
    }
}

