using System.Collections.Generic;
using UnityEngine;

namespace SpawnEnemies
{
    public class SpawnPointProvider : MonoBehaviour
    {
        [SerializeField] private GameObject _spawnPointParent;
        [SerializeField] private List<SpawnPoint> _spawnPoints;

        [ContextMenu("Fill spawn points")]
        public void FillSpawnPoints()
        {
            if (_spawnPointParent == null)
                return;

            var spawnPoints = _spawnPointParent.GetComponentsInChildren<SpawnPoint>();

            foreach (var spawnPoint in spawnPoints)
            {
                _spawnPoints.Add(spawnPoint);
            }
        }

        public Vector3 GetRandomSpawnPoint()
        {
            if (_spawnPoints.Count == 0)
            {
                Debug.Log("Spawn point list is empty");
                return Vector3.zero;
            }

            int index = Random.Range(0, _spawnPoints.Count);
            return _spawnPoints[index].transform.position;
        }
    }
}

