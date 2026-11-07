using System;
using UnityEngine;

namespace ExplosiveCubes
{
    public class CubeDetonator : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _maxDistance = 50f;
        [SerializeField] private MouseClickEvent _mouseEvent;

        private Ray _ray;

        public event Action<ExplosiveCube> CubeClicked;

        private void OnEnable()
        {
            _mouseEvent.Clicked += SendTargetForDetonate;
        }

        private void OnDisable()
        {
            _mouseEvent.Clicked -= SendTargetForDetonate;
        }

        private void SendTargetForDetonate()
        {
            var target = FindCubeByRaycast();

            if (target != null)
                CubeClicked?.Invoke(target);
        }

        private ExplosiveCube FindCubeByRaycast()
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
        
            RaycastHit[] hits;
            hits = Physics.RaycastAll(_ray, _maxDistance);

            foreach (var hit in hits)
                if (hit.transform.gameObject.TryGetComponent<ExplosiveCube>(out var cube))
                    return cube;

            return null;
        }
    }
}


