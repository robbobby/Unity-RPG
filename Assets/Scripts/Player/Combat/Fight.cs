using System.Collections;
using System.Collections.Generic;
using Monster.Target;
using UnityEngine;

namespace Player.Combat {
    public class Fighter : MonoBehaviour {
        private void Start() {
            print("Will Move to target and attack"); }

        private void Update() { }

        public void Attack(Target target) {
            throw new System.NotImplementedException();
        }
    }
}