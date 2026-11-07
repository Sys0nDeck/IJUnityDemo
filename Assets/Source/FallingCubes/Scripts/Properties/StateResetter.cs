using UnityEngine;

namespace FallingCubes
{
    public class StateResetter : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigitbody;

        private void OnEnable()
        {
            ResetParameters();
        }

        private void ResetParameters()
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            _rigitbody.velocity = Vector3.zero;
            _rigitbody.angularVelocity = Vector3.zero;
        }
    }
}


