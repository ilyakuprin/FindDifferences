using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Zenject;

namespace _FindDifferences.Scripts.Timer
{
    public class TimeCounter : IInitializable, IDisposable
    {
        public event Action<float> Counted;
        public event Action TimeUp;

        private const float Time = 120f;
        
        private readonly CancellationTokenSource _cts = new ();

        private float _time = Time;
        
        public void Initialize()
            => StartCount();

        public void Dispose()
        {
            if (_cts.IsCancellationRequested) return;
            
            _cts.Cancel();
            _cts.Dispose();
        }

        public void AddTime(float value)
        {
            if (value > 0)
                _time += value;
        }

        private void StartCount()
            => Count().Forget();

        private async UniTask Count()
        {
            while (!_cts.IsCancellationRequested && _time > 0)
            {
                _time -= UnityEngine.Time.deltaTime;
                await UniTask.NextFrame(_cts.Token);
                
                if (_time < 0)
                    _time = 0;
                
                Counted?.Invoke(_time);
            }
            
            if (!_cts.IsCancellationRequested && _time <= 0)
                TimeUp?.Invoke();
        }
    }
}
