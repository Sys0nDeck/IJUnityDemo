using System.Collections.Generic;
using UnityEngine;

namespace ExplosiveCubes
{
    public class CubeExploder : MonoBehaviour
    {
        [SerializeField] private float _explosiveForce = 10f;
        [SerializeField] private float _explosiveRadius = 2f;

        public void Explode(List<Rigidbody> explodableObjects, Vector3 centerOfExplosion)
        {
            foreach (Rigidbody explodableObject in explodableObjects)
                explodableObject.AddExplosionForce(_explosiveForce, centerOfExplosion, _explosiveRadius);
        }

        public void ExplodeWithDistance(List<Rigidbody> explodableObjects, Vector3 centerOfExplosion, float explodeCoeff)
        {
            float explosiveForce = _explosiveForce * explodeCoeff;
            float explosiveRadius = _explosiveRadius * explodeCoeff;

            foreach (var explodableObject in explodableObjects)
            {
                float distanceFromExplosion = (explodableObject.transform.position - centerOfExplosion).magnitude;
                float explosionForceCoeff = 1.0f - (distanceFromExplosion / _explosiveRadius);
                float currentExplosiveForce = explosiveForce * explosionForceCoeff;

                explodableObject.AddExplosionForce(currentExplosiveForce, centerOfExplosion, explosiveRadius);
            }
        }

        public List<Rigidbody> GetExplodableObjects(Vector3 centerOfExplosion)
        {
            var explodableObjects = new List<Rigidbody>();
            var colliders = Physics.OverlapSphere(centerOfExplosion, _explosiveRadius);

            foreach (var collider in colliders)
                if (collider.TryGetComponent<Rigidbody>(out var rigidbody))
                    explodableObjects.Add(rigidbody);

            return explodableObjects;
        }
    }
}
