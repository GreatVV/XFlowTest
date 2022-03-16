using DG.Tweening;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.UnityEditor;
using UnityEngine;

namespace Xflow 
{
    sealed class Startup : MonoBehaviour {
        [SerializeField] SceneData _sceneData;
        [SerializeField] Configuration _config;

        EcsSystems _systems;

        void Start () {
            _systems = new EcsSystems (new EcsWorld ());
           

            _systems
                .Add (new PlayerInitSystem ())
                .Add (new UserInputSystem ())
                .Add (new PlayerMoveSystem ())
                .Add (new PlayerPosSyncSystem ())
                .Add (new MoveFlagViewSystem ())
                .Add (new DoorOpenSystem ())
                .AddWorld (new EcsWorld (), Idents.Worlds.Events)
#if UNITY_EDITOR
                .Add (new EcsWorldDebugSystem ())
                .Add (new EcsWorldDebugSystem (Idents.Worlds.Events))
#endif
                .Inject (_sceneData, _config)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                DOTween.KillAll ();
                _systems.Destroy ();
                _systems.GetWorld ().Destroy ();
                _systems = null;
            }
        }
    }
}