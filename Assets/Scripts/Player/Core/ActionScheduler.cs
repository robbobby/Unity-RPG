using UnityEngine;

namespace Player.Core {
    public class ActionScheduler : MonoBehaviour {
        private IAction m_currentAction;
        public void StartAction(IAction action) {
            if (m_currentAction == action) return;
            if (m_currentAction != null) {
                print("Canceling " + m_currentAction);
                m_currentAction = action;
                m_currentAction.CancelAction();
            }
            m_currentAction = action;
        }
    }
}