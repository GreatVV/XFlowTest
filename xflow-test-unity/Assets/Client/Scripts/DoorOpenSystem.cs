using DG.Tweening;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Xflow {
    sealed class DoorOpenSystem : IEcsRunSystem {
        readonly EcsFilterInject<Inc<DoorOpenEvent>> _events = Idents.Worlds.Events;

        public void Run (EcsSystems systems) {
            foreach (var entity in _events.Value) {
                ref var e = ref _events.Pools.Inc1.Get (entity);
                e.DoorView.Transform.DOMoveY (e.DoorView.Transform.position.y +  5f, 2f);
                e.DoorButtonTransform.DOMoveY (e.DoorButtonTransform.position.y - 0.1f, 2f);
                e.DoorView.Obstacle.carving = false;
                _events.Pools.Inc1.Del (entity);
            }
        }
    }
}