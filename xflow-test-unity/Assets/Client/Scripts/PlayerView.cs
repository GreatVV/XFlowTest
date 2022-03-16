using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.AI;

namespace Xflow {
    sealed class PlayerView : MonoBehaviour
    {
        public Configuration Config;
        public Animator Animator;
        public NavMeshAgent Agent;
        public Transform Transform;
        public EcsPool<DoorOpenEvent> DoorEventPool;

        void OnTriggerEnter (Collider other) {
            other.enabled = false;

            if (other.gameObject.TryGetComponent (out DoorButtonView doorButtonView)) {
                ref var e = ref DoorEventPool.Add (DoorEventPool.GetWorld ().NewEntity ());
                e.DoorButtonView = doorButtonView;
                e.DoorView = doorButtonView.DoorView;
            }
        }

        public void SetDestination (in Vector3 pos) {
            Agent.SetDestination (pos);
            SetRunning (true);
        }

        public void SetRunning (bool state) {
            Animator.SetBool (Config.AnimatorMovingParam, state);
        }
    }
}