using System;
using System.Collections;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _delay = 2;

        private Coroutine _coroutine;

        public event Action TimeTicked;

        private void OnDisable()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        public void Run()
        {
            _coroutine = StartCoroutine(TimeStart(_delay));
        }

        private IEnumerator TimeStart(float delay)
        {
            var time = new WaitForSeconds(delay);

            while (true)
            {
                yield return time;
                TimeTicked?.Invoke();
            }
        }
    }
}


