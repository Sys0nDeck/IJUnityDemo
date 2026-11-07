using System;
using UnityEngine;

namespace ExplosiveCubes
{
    public class MouseClickEvent : MonoBehaviour
    {
        private const int LeftMouseButton = 0;

        public event Action Clicked;

        private void Update()
        {
            if (Input.GetMouseButtonDown(LeftMouseButton))
            {
                Clicked?.Invoke();
            }
        }
    }
}
