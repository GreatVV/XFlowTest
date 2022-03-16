using UnityEngine;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Xflow {
    sealed class PlayerInitSystem : IEcsInitSystem {
        readonly EcsCustomInject<Configuration> _config = default;
        readonly EcsCustomInject<SceneData> _sceneData = default;

        readonly EcsPoolInject<Player> _playerPool = default;

        readonly EcsPoolInject<DoorOpenEvent> _doorEventPool = Idents.Worlds.Events;
        
        public void Init (EcsSystems systems) {
            ref var player = ref _playerPool.Value.Add (_playerPool.Value.GetWorld ().NewEntity ());

            player.View = Object.Instantiate (_config.Value.PlayerPrefab, _sceneData.Value.PlayerSpawnPoint.position, Quaternion.identity);
            player.View.DoorEventPool = _doorEventPool.Value;
        }
    }
}