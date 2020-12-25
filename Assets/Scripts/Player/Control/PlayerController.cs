using System.Collections;
using System.Collections.Generic;
using Monster.Target;
using Player.Combat;
using UnityEngine;

namespace Player.Control {
    public class PlayerController : MonoBehaviour {
        private UnityEngine.Camera m_camera;
        private Movement.Movement m_movement;
        private Fighter m_fighter;
        private bool hasTarget;

        private void Start() {
            m_fighter = GetComponent<Fighter>();
            m_movement = GetComponent<Movement.Movement>();
            m_camera = UnityEngine.Camera.main;
            hasTarget = false;
            
        }
        private void Update() {
            if (HandleMouseState()) return;
            print("HandMouseState not called");
        }
        private bool HandleMouseState() {
            if (Input.GetMouseButton(0)) {
                CheckWhatCursorClicked();
                return true;
            }
            if (Input.GetMouseButtonUp(0) && !hasTarget) {
                m_movement.StopMovement();
                return true;
            }
            return false;
        }

        private void CheckWhatCursorClicked() {
            hasTarget = false;
            Ray ray = GetMouseRay();
            if (HasClickedMonster()) { return; }
            SetMovePosition(ray);
        }
        private void SetMovePosition(Ray ray) {
            bool hasDestination = Physics.Raycast(ray, out var positionToMoveTo);
            if (hasDestination) {
                m_movement.SetMove(positionToMoveTo.point);
            }
        }
        private void SetMonsterTarget() {
        }
        private bool HasClickedMonster() {
            var hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits) {
                Target target = hit.transform.GetComponent<Target>();
                if (target == null) continue;
                HasClickedTarget(target);
                hasTarget = true;
                SetMovePosition(GetMouseRay());
                return true;
            }
            return false;
        }
        private void HasClickedTarget(Target target) {
            // if (Input.GetMouseButtonDown(0)) m_fighter.Attack(target);
        }
        private Ray GetMouseRay() {
            return m_camera.ScreenPointToRay(Input.mousePosition);
        }
    }
}
