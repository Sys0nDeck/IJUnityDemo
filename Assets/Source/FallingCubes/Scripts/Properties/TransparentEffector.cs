using System.Collections;
using UnityEngine;

namespace FallingCubes
{
    [RequireComponent(typeof(Renderer))]
    public class TransparentEffector : MonoBehaviour
    {
        private Material _material;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
        }

        private void OnEnable()
        {
            float maxAlpha = 1.0f;
            SetAlpha(maxAlpha);
        }

        public void StartFading(float fadeTime)
        {
            StartCoroutine(Fade(fadeTime));
        }

        private void SetAlpha(float value)
        {
            Color defaultColor = _material.color;
            Color newColor = new Color(defaultColor.r, defaultColor.g, defaultColor.b, value);
            _material.color = newColor;
        }

        private IEnumerator Fade(float time)
        {
            float passedTime = 0;

            while (passedTime < time)
            {
                var offset = passedTime / time;
                SetAlpha(Mathf.Lerp(1f, 0f, offset));
                passedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}

