using System.Collections.Generic;
using UnityEngine;

namespace ExplosiveCubes
{
    [RequireComponent(typeof(CubeSpawner))]
    [RequireComponent (typeof(CubeExploder))]

    public class CubeClickHandler : MonoBehaviour
    {
        [SerializeField] private CubeDetonator _detonator;

        private CubeSpawner _cubeSpawner;
        private CubeExploder _cubeExploder;

        private void Awake()
        {
            _cubeSpawner = GetComponent<CubeSpawner>();
            _cubeExploder = GetComponent<CubeExploder>();
        }

        private void OnEnable()
        {
            _detonator.CubeClicked += Detonate;
        }

        private void OnDisable()
        {
            _detonator.CubeClicked -= Detonate;
        }

        private void Detonate(ExplosiveCube target)
        {
            var centerOfExplosion = target.transform.position;

            if (Random.value <= target.SplitChance)
            {
                _cubeSpawner.Spawn(target.gameObject);
                _cubeExploder.Explode(GetRigidbodies(_cubeSpawner.GetSpawnedObjects), centerOfExplosion);
            }
            else
            {
                var rigitbodies = _cubeExploder.GetExplodableObjects(centerOfExplosion);
                _cubeExploder.ExplodeWithDistance(rigitbodies, centerOfExplosion, target.ExplosiveCoeff);
            }

            Destroy(target.gameObject);
        }

        private List<Rigidbody> GetRigidbodies(List<GameObject> objects)
        {
            var bodies = new List<Rigidbody>();

            foreach (GameObject obj in objects)
            {
                if (obj.TryGetComponent<Rigidbody>(out var body))
                {
                    bodies.Add(body);
                }
            }

            return bodies;
        }
    }
}