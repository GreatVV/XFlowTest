using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Xflow {
    sealed class TimeSystem : IEcsRunSystem {
        readonly EcsCustomInject<TimeService> _ts = default;

        public void Run (EcsSystems systems) {
            _ts.Value.Time = Time.time;
            _ts.Value.DeltaTime = Time.deltaTime;
            _ts.Value.UnscaledDeltaTime = Time.unscaledDeltaTime;
        }
    }
}