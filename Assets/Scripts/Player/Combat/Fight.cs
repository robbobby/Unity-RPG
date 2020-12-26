using System.Collections;
using System.Collections.Generic;
using Monster.Target;
using Player.Control;
using Player.Core;
using UnityEngine;
using Player.Move;
using UnityEngine.AI;

namespace Player.Combat {
    public class Fight : MonoBehaviour, IAction {
        [SerializeField] private float attackRange = 2f;
        private Move.Movement m_movement;
        private Transform m_target;
        private ActionScheduler m_actionScheduler;
        private void Start() {
            m_movement = GetComponent<Movement>();
            m_actionScheduler = GetComponent<ActionScheduler>();
        }
        public bool ContinueAttack() {
            if (!IsInRange()) {
               m_movement.SetMove(m_target.position);
               return true;
            }
            m_movement.StopMovement();
            return false;
        }
        public void SetAttack(Transform target) {
            m_actionScheduler.StartAction(this);
            m_target = target.transform;
        }

        private bool IsInRange() 
            => Vector3.Distance(this.transform.position, m_target.transform.position) < attackRange;
        public void CancelAction() {
            m_movement.StopMovement();
        }
    }
}