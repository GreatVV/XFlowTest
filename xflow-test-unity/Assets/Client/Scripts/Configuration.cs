using UnityEngine;

namespace Xflow {
    [CreateAssetMenu]
    sealed class Configuration : ScriptableObject {
        public PlayerView PlayerPrefab;
        public GameObject MoveFlag;
    }
}