using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Xflow {
    sealed class MoveFlagViewSystem : IEcsInitSystem, IEcsRunSystem {
        readonly EcsCustomInject<Configuration> _config = default;

        readonly EcsFilterInject<Inc<Player>> _players = default;

        GameObject _moveFlag;

        public void Init (EcsSystems systems) {
            _moveFlag = Object.Instantiate (_config.Value.MoveFlag, Vector3.zero, Quaternion.identity);
            _moveFlag.SetActive (false);
        }

        public void Run (EcsSystems systems) {
            foreach (var entity in _players.Value) {
                ref var player = ref _players.Pools.Inc1.Get (entity);
                if (player.DestinationPos == default) {
                    return;
                }
                _moveFlag.transform.position = player.DestinationPos;
                var tooClose = (player.Position - _moveFlag.transform.position).sqrMagnitude <= 4f;
                if (tooClose && _moveFlag.activeSelf) {
                    _moveFlag.SetActive (false);
                    continue;
                }

                if (!tooClose && !_moveFlag.activeSelf) {
                    _moveFlag.SetActive (true);
                }
            }
        }
    }
}