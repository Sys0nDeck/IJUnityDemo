using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingCubes
{
    public class Detonator : MonoBehaviour
    {
        [SerializeField] private float _explosionForce;
        [SerializeField] private float _explosionRadius;

        public void Explode()
        {
            var explodableObjects = GetExplodableObjects(transform.position);

            foreach (Rigidbody explodableObject in explodableObjects)
            {
                explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }

        public List<Rigidbody> GetExplodableObjects(Vector3 centerOfExplosion)
        {
            var explodableObjects = new List<Rigidbody>();
            var colliders = Physics.OverlapSphere(centerOfExplosion, _explosionRadius);

            foreach (var collider in colliders)
                if (collider.TryGetComponent<Rigidbody>(out var rigidbody))
                    explodableObjects.Add(rigidbody);

            return explodableObjects;
        }
    }
}

