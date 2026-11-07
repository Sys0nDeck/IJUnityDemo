using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    [RequireComponent(typeof(ArrivalNotifier))]
    [RequireComponent(typeof(WaypointFollower))]
    [RequireComponent(typeof(WaypointDirectionProvider))]
    [RequireComponent(typeof(EnemyKiller))]
    public class Target : MonoBehaviour { }
}

