using UnityEngine;

namespace Xflow {
    sealed class DoorButtonView : MonoBehaviour {
        public DoorView DoorView;
        public Transform Transform;
        public float DownOffset;
        public float MoveDuration;
    }
}