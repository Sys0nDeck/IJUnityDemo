using System;
using System.Collections;
using UnityEngine;

namespace FallingCubes
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private TransparentEffector _effector;
        [SerializeField] private Detonator _detonator;

        private Coroutine _countdownCoroutine;

        public event Action<Bomb> Exploded;

        private void OnEnable()
        {
            _countdownCoroutine = StartCoroutine(StartCountdown(_lifeTime));
            _effector.StartFading(_lifeTime);
        }

        private void OnDisable()
        {
            if (_countdownCoroutine != null)
            {
                StopCoroutine(_countdownCoroutine);
                _countdownCoroutine = null;
            }
        }

        public void Init(float lifeTime)
        {
            _lifeTime = lifeTime;
        }

        private IEnumerator StartCountdown(float time)
        {
            yield return new WaitForSeconds(time);
            _detonator.Explode();
            Exploded?.Invoke(this);
        }
    }
}

