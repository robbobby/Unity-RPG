using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    private Ray _lastRay;
    private Camera _camera;

    private void Start() {
        _camera = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            this._lastRay = _camera.ScreenPointToRay(Input.mousePosition);
        }
        Debug.DrawRay(this._lastRay.origin, this._lastRay.direction * 100 );
        GetComponent<NavMeshAgent>().destination = target.position; 
    }
}
