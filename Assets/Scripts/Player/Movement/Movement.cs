using Player.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Player.Move {
    public class Movement : MonoBehaviour, IAction {
        [SerializeField] Transform target;
        private NavMeshAgent m_navMeshAgent;
        private Animator m_animator;
        private ActionScheduler m_actionScheduler;

        private void Start() {
            m_animator = GetComponent<Animator>();
            m_navMeshAgent = GetComponent<NavMeshAgent>();
            m_actionScheduler = GetComponent<ActionScheduler>();
        }

        private void Update() {
            UpdateAnimator();
        }

        internal void StopMovement() {
            m_navMeshAgent.ResetPath();
        }

        private void UpdateAnimator() {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            m_animator.SetFloat("forwardSpeed", speed);
        }

        internal void SetMove(Vector3 positionToMoveTo) {
            m_actionScheduler.StartAction(this);
            m_navMeshAgent.destination = positionToMoveTo;
        }

        public void CancelAction() {
            StopMovement();
        }
    }
    
}