using System;
using _FindDifferences.Scripts.Difference;
using Zenject;

namespace _FindDifferences.Scripts.Timer
{
    public class StoppingTimer : IInitializable, IDisposable
    {
        private readonly TimeCounter _timeCounter;
        private readonly CountingFound _countingFound;

        public StoppingTimer(TimeCounter timeCounter,
                             CountingFound countingFound)
        {
            _timeCounter = timeCounter;
            _countingFound = countingFound;
        }

        public void Initialize()
            => _countingFound.Won += Stop;

        public void Dispose()
            => _countingFound.Won -= Stop;

        private void Stop()
            => _timeCounter.Dispose();
    }
}