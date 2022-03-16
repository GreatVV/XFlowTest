using UnityEngine;
using UnityEngine.AI;

namespace Xflow {
    sealed class DoorView : MonoBehaviour {
        public NavMeshObstacle Obstacle;
        public Transform Transform;
        public float UpOffset;
        public float MoveDuration;
    }
}