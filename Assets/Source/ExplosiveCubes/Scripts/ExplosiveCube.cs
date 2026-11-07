using UnityEngine;

namespace ExplosiveCubes 
{
    [RequireComponent(typeof(Rigidbody))]
    public class ExplosiveCube : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float _splitChance = 1f;
        [SerializeField] private float _explosiveCoeff = 1f;

        public float SplitChance
        {
            get { return _splitChance; }
            private set { _splitChance = value; }
        }

        public float ExplosiveCoeff
        {
            get { return _explosiveCoeff; }
            private set { _explosiveCoeff = value; }
        }

        public void Initialize(float splitChance, Vector3 scale, float explosiveCoeff)
        {
            _splitChance = splitChance;
            transform.localScale = scale;
            _explosiveCoeff = explosiveCoeff;
        }
    }
}
