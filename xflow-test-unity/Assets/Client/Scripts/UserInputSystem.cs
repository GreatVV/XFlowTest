using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Xflow {
    sealed class UserInputSystem : IEcsRunSystem {
        readonly EcsPoolInject<MoveEvent> _moveEventPool = Idents.Worlds.Events;
        readonly EcsCustomInject<SceneData> _scene = default;

        public void Run (EcsSystems systems) {
            if (Input.GetMouseButtonDown (0)) {
                var cam = _scene.Value.MainCamera;

                var ray = cam.ScreenPointToRay (Input.mousePosition);

                if (Physics.Raycast (ray, out var hit))
                    if (hit.collider.gameObject.CompareTag (Idents.Tags.Ground)) {
                        ref var e = ref _moveEventPool.Value.Add (_moveEventPool.Value.GetWorld ().NewEntity ());

                        e.WorldPos = hit.point;
                    }
            }
        }
    }
}