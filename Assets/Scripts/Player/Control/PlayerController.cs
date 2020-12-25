using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Player.Control {
    public class PlayerController : MonoBehaviour {
        private Camera m_camera;
        private Movement m_movement;
        private void Start() {
            m_movement = GetComponent<Movement>();
            m_camera = Camera.main;
        }
        private void Update() {
            CheckMouseState();
        }
        private void CheckMouseState() {
            if (Input.GetMouseButton(0)) {
                MoveToCursor();
            }

            if (Input.GetMouseButtonUp(0)) {
                m_movement.StopMovement();
            }
        }

        // Start is called before the first frame update
        private void MoveToCursor() {
            Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
            bool hasDestination = Physics.Raycast(ray, out var positionToMoveTo);
            if (hasDestination) {
                m_movement.SetMove(positionToMoveTo.point);
            }
        }
    }
}