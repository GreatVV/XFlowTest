using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.AI;

namespace Xflow {
    sealed class PlayerView : MonoBehaviour {
        public EcsPool<DoorOpenEvent> DoorEventPool;
        public Animator Animator;
        public NavMeshAgent Agent; 
        public Transform Transform;

        void OnTriggerEnter (Collider other) {
            var go = other.gameObject;
            go.SetActive (false);

            if (go.TryGetComponent (out DoorButtonView doorButtonView)) {
                ref var e = ref DoorEventPool.Add (DoorEventPool.GetWorld ().NewEntity ());
                e.DoorView = doorButtonView.DoorView;
            }
        }

        public void SetDestination (in Vector3 pos) {
            Agent.SetDestination (pos);
        }
    }
}