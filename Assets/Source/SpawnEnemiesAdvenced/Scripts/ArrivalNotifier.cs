using System;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class ArrivalNotifier : MonoBehaviour
    {
        private float _minDistanceToWaypoint = 0.2f;
        private Waypoint _waypoint;

        public event Action WaypointApproached;

        private void Update()
        {
            if (_waypoint == null)
                return;

            if (IsReached(_waypoint))
                Notify();
        }

        public void SetWaypoint(Waypoint waypoint)
        {
            _waypoint = waypoint;
        }

        private bool IsReached(Waypoint waypoint)
        {
            var offset = waypoint.transform.position - transform.position;
            float sqrLength = offset.sqrMagnitude;
            return sqrLength <= Mathf.Pow(_minDistanceToWaypoint, 2);
        }

        private void Notify()
            => WaypointApproached?.Invoke();
    }
}

