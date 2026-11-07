using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GismosRay : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 10f);
    }

    private void Update()
    {

    }
}
