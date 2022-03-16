using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Xflow {
    sealed class PlayerPosSyncSystem : IEcsRunSystem {
        private readonly EcsCustomInject<Configuration> _config = default;

        readonly EcsFilterInject<Inc<Player>> _players = default;

        public void Run (EcsSystems systems) {
            foreach (var entity in _players.Value) {
                ref var player = ref _players.Pools.Inc1.Get (entity);
                player.Position = player.View.Transform.position;

                if ((player.Position - player.DestinationPos).sqrMagnitude <= _config.Value.RunAnimationStopSqrDistance) player.View.SetRunning (false);
            }
        }
    }
}