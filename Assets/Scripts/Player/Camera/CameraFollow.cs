using UnityEngine;

namespace Player.Camera {

    public class CameraFollow : MonoBehaviour {
        [SerializeField] private Transform target;
        private void LateUpdate() {
            this.transform.position = target.position;
        }
    }
}