using System;
using Zenject;

namespace _FindDifferences.Scripts.Timer
{
    public class Showing : IInitializable, IDisposable
    {
        private readonly View _view;
        private readonly TimeCounter _timeCounter;
        
        public Showing(TimeCounter timeCounter,
                       View view)
        {
            _timeCounter = timeCounter;
            _view = view;
        }

        public void Initialize()
            => _timeCounter.Counted += Show;

        public void Dispose()
            => _timeCounter.Counted -= Show;

        private void Show(float time)
        {
            var ts = TimeSpan.FromSeconds(time);
            _view.TextTimer.text = $"{ts.Minutes:00}:{ts.Seconds:00}";
        }
    }
}
