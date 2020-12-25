using System;
using System.Collections;
using System.Collections.Generic;
using Monster.Target;
using Player.Combat;
using Player.Move;
using UnityEngine;
using UnityEngine.AI;

namespace Player.Control {
    public class PlayerController : MonoBehaviour {
        private UnityEngine.Camera m_camera;
        private Move.Movement m_movement;
        private Fight m_fighter;
        public bool hasTarget;

        private void Start() {
            m_fighter = GetComponent<Fight>();
            m_movement = GetComponent<Movement>();
            m_camera = UnityEngine.Camera.main;
            SetHasTarget(false);
        }
        private void Update() {
            HandleMouseState();
            if(hasTarget) {
                hasTarget = m_fighter.ContinueAttack();
            }
        }
        private bool HandleMouseState() {
            if (Input.GetMouseButton(0)) {
                CheckWhatCursorClicked();
                return true;
            }
            if (!Input.GetMouseButtonUp(0)) return false;
            m_movement.StopMovement();
            return true;
        }
        private void CheckWhatCursorClicked() {
            SetHasTarget(false);
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
        private bool HasClickedMonster() {
            var hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits) {
                Target target = hit.transform.GetComponent<Target>();
                if (target == null) continue;
                SetHasTarget();
                m_fighter.SetAttack(target.transform);
                return true;
            }
            return false;
        }
        private Ray GetMouseRay() {
            return m_camera.ScreenPointToRay(Input.mousePosition);
        }

        public void SetHasTarget(bool isTargeting = true) { hasTarget = isTargeting; }
    }
}
