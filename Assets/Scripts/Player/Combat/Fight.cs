using System.Collections;
using System.Collections.Generic;
using Monster.Target;
using Player.Control;
using UnityEngine;
using Player.Move;
using UnityEngine.AI;

namespace Player.Combat {
    public class Fight : MonoBehaviour {
        [SerializeField] private float attackRange = 2f;
        private Move.Movement m_movement;
        private Transform m_target;
        private void Start() {
            m_movement = GetComponent<Movement>();
        }
        public bool ContinueAttack() {
            if (!InRange(m_target)) {
                SetMovePosition();
                return true;
            }
            m_movement.StopMovement();
            return false;
        }
        public void SetAttack(Transform target) {
            m_target = target.transform;
        }
        private bool InRange(Transform target) 
            => Vector3.Distance(this.transform.position, target.transform.position) < attackRange;
        private void SetMovePosition() {
            m_movement.SetMove(m_target.position);
        }
    }
}