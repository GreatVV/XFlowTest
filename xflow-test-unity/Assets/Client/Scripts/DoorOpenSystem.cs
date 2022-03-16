using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Xflow {
    sealed class DoorOpenSystem : IEcsRunSystem {
        readonly EcsFilterInject<Inc<DoorOpenEvent>> _events = default;

        public void Run (EcsSystems systems) {
            // todo door open, obstacle turn off.
        }
    }
}