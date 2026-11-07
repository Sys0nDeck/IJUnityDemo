using System.Collections.Generic;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class SpawnPointSelector : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints;

        public bool IsEmpty => _spawnPoints.Count == 0;

        [ContextMenu("Fill spawn points")]
        public void FillSpawnPoints()
        {
            _spawnPoints = new List<SpawnPoint>(GetComponentsInChildren<SpawnPoint>());
        }

        public SpawnPoint GetRandomSpawnPoint()
        {
            if (_spawnPoints.Count == 0)
            {
                Debug.Log("Spawn point list is empty");
                return null;
            }

            int index = Random.Range(0, _spawnPoints.Count);
            return _spawnPoints[index];
        }
    }
}

