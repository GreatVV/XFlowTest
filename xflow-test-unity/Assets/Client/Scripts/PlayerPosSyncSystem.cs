using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Xflow {
    sealed class PlayerPosSyncSystem : IEcsRunSystem {
        readonly EcsFilterInject<Inc<Player>> _players = default;

        public void Run (EcsSystems systems) {
            foreach (var entity in _players.Value) {
                ref var player = ref _players.Pools.Inc1.Get (entity);
                player.Position = player.View.Transform.position;

                if ((player.Position - player.DestinationPos).sqrMagnitude <= 0.5f) {
                    player.View.SetRunning (false);
                }
            }
        }
    }
}