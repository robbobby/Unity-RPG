using UnityEngine;
using UnityEngine.AI;

namespace Player.Movement {
    public class Movement : MonoBehaviour {
        [SerializeField] Transform target;
        private NavMeshAgent m_navMeshAgent;
        private Animator m_animator;
        private void Start() {
            m_animator = GetComponent<Animator>();
            m_navMeshAgent = GetComponent<NavMeshAgent>();
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
            m_navMeshAgent.destination = positionToMoveTo;
        }
    }
}
