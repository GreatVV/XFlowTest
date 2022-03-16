using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Xflow {
    sealed class PlayerInitSystem : IEcsInitSystem 
    {
        readonly EcsCustomInject<Configuration> _config = default;
        readonly EcsCustomInject<SceneData> _sceneData = default;

        readonly EcsPoolInject<DoorOpenEvent> _doorEventPool = Idents.Worlds.Events;
        readonly EcsPoolInject<Player> _playerPool = default;

        public void Init (EcsSystems systems) 
        {
            ref var player = ref _playerPool.Value.Add(_playerPool.Value.GetWorld ().NewEntity ());

            player.View = Object.Instantiate (_config.Value.PlayerPrefab, _sceneData.Value.PlayerSpawnPoint.position, Quaternion.identity);
            player.View.DoorEventPool = _doorEventPool.Value;
        }
    }
}