using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Xflow {
    sealed class PlayerMoveSystem : IEcsRunSystem {
        readonly EcsFilterInject<Inc<Player>> _players = default;
        readonly EcsFilterInject<Inc<MoveEvent>> _moveEvents = Idents.Worlds.Events;

        public void Run (EcsSystems systems) {
            if (_moveEvents.Value.GetEntitiesCount () == 0) {
                return;
            }

            Vector3 pos = default;
            foreach (var entity in _moveEvents.Value) {
                ref var e = ref _moveEvents.Pools.Inc1.Get (entity);

                pos = e.WorldPos;
                _moveEvents.Value.GetWorld ().DelEntity (entity);
            }

            foreach (var entity in _players.Value) {
                ref var player = ref _players.Pools.Inc1.Get (entity);

                player.DestinationPos = pos;
                player.View.SetDestination (pos);
            }
        }
    }
}