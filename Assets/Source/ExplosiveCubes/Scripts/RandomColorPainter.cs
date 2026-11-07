using UnityEngine;

namespace ExplosiveCubes
{
    public class RandomColorPainter : MonoBehaviour
    {
        private void Start()
        {
            SetRandomColor();
        }

        private void SetRandomColor()
           => gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0, 1, 0, 1, 0, 1, 1, 1);
    }
}
