using System.Collections.Generic;
using UnityEngine;

namespace ExplosiveCubes
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private int _minSplitParts = 2;
        [SerializeField] private int _maxSplitParts = 6;

        private List<GameObject> _spawnedObjects;

        public List<GameObject> GetSpawnedObjects
            => new List<GameObject>(_spawnedObjects);

        private void Awake()
        {
            _spawnedObjects = new List<GameObject>();
        }

        public void Spawn(GameObject prefab)
        {
            int objectCount = Random.Range(_minSplitParts, _maxSplitParts + 1);
            var spawnedObjects = new List<GameObject>();

            for (int i = 0; i < objectCount; i++)
            {
                Vector3 spawnPosition = prefab.transform.position +
                    new Vector3(Random.insideUnitSphere.x,
                                prefab.transform.position.y * 0.5f,
                                Random.insideUnitSphere.z);

                GameObject spawnedObject = Instantiate(prefab, spawnPosition, Random.rotation);
                InitializeSpawnedObjects(prefab, spawnedObject);
                spawnedObjects.Add(spawnedObject);
            }

            _spawnedObjects = spawnedObjects;
        }

        private void InitializeSpawnedObjects(GameObject prefab, GameObject spawnedObject)
        {
            var prefabData = prefab.GetComponent<ExplosiveCube>();
            float spawnedObjectSplitChance = prefabData.SplitChance * 0.5f;
            Vector3 spawnedObjectScale = prefab.transform.localScale * 0.5f;

            spawnedObject.GetComponent<ExplosiveCube>().
                Initialize(spawnedObjectSplitChance, 
                            spawnedObjectScale,
                            prefabData.ExplosiveCoeff * 2f);
        }
    }
}
