using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    [RequireComponent(typeof(Rotator))]
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(WaypointFollower))]
    public class WaypointDirectionProvider : MonoBehaviour
    {
        private Rotator _rotator;
        private Mover _mover;
        private WaypointFollower _waypointFollower;

        private void Awake()
        {
            _rotator = GetComponent<Rotator>();
            _mover = GetComponent<Mover>();
            _waypointFollower = GetComponent<WaypointFollower>();
        }

        private void OnEnable()
        {
            _waypointFollower.WaypointChanged += TrackNewWaypoint;
        }

        private void OnDisable()
        {
            _waypointFollower.WaypointChanged -= TrackNewWaypoint;
        }

        private void TrackNewWaypoint(Waypoint waypoint)
        {
            _mover.SetTarget(waypoint.transform);
            _rotator.SetTarget(waypoint.transform);
        }
    }
}

