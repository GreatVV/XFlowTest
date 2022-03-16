using UnityEngine;

namespace Xflow
{
    [CreateAssetMenu]
    sealed class Configuration : ScriptableObject {
        public PlayerView PlayerPrefab;
        public GameObject MoveFlag;
        public string GroundTag;
        public string AnimatorMovingParam;
        public float FlagHideSqrDistance;
        public float RunAnimationStopSqrDistance;
    }
}