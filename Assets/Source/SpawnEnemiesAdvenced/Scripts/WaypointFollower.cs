using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    [RequireComponent(typeof(ArrivalNotifier))]
    public class WaypointFollower : MonoBehaviour
    {
        [SerializeField] private WaypointRepos _waypointRepos;
        private ArrivalNotifier _arrivalNotifier;

        public event Action<Waypoint> WaypointChanged;

        private void Awake()
        {
            _arrivalNotifier = GetComponent<ArrivalNotifier>();
        }

        private void Start()
        {
            SendNextWaypoint();
        }

        private void OnEnable()
        {
            _arrivalNotifier.WaypointApproached += SendNextWaypoint;
        }

        private void OnDisable()
        {
           _arrivalNotifier.WaypointApproached -= SendNextWaypoint;
        }

        private void SendNextWaypoint()
        {
            if (_waypointRepos == null)
            {
                Debug.Log("Waypoint is empty");
                return;
            }

            var newWaypoint = _waypointRepos.GetWaypoint();
            WaypointChanged?.Invoke(newWaypoint);
            _arrivalNotifier.SetWaypoint(newWaypoint);
        }
    }
}

