using UnityEngine;
using UnityEngine.AI;

namespace Player {
    public class Movement : MonoBehaviour {
        [SerializeField] Transform target;
        private Camera _camera;
        private void Start() {
            _camera = Camera.main;
        }
        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                MoveToCursor();
            }
        }
        private void MoveToCursor() {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            bool hasHit = Physics.Raycast(ray, out var positionToMoveTo);
            if (hasHit) {
                GetComponent<NavMeshAgent>().destination = positionToMoveTo.point;
            }
        }
    }
}
