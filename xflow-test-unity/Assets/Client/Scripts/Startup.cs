using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Xflow {
    sealed class Startup : MonoBehaviour {
        [SerializeField] SceneData _sceneData;
        [SerializeField] Configuration _config;

        EcsSystems _systems;

        void Start () {
            _systems = new EcsSystems (new EcsWorld ());
            var ts = new TimeService ();

            _systems
                .Add (new TimeSystem ())
                .Add (new PlayerInitSystem ())
                .Add (new UserInputSystem ())
                .Add (new PlayerMoveSystem ())
                .Add (new PlayerPosSyncSystem ())
                .Add (new MoveFlagViewSystem ())
                .Add (new DoorOpenSystem ())
                .AddWorld (new EcsWorld (), Idents.Worlds.Events)
#if UNITY_EDITOR
                .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
                .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem (Idents.Worlds.Events))
#endif
                .Inject (ts, _sceneData, _config)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems.GetWorld ().Destroy ();
                _systems = null;
            }
        }
    }
}