using System;
using _FindDifferences.Scripts.Timer;
using Zenject;

namespace _FindDifferences.Scripts.UI
{
    public class ShowingDefeat : IInitializable, IDisposable
    {
        private readonly TimeCounter _timeCounter;
        private readonly View _view;

        public ShowingDefeat(View view,
                             TimeCounter timeCounter)
        {
            _view = view;
            _timeCounter = timeCounter;
        }

        public void Initialize()
            => _timeCounter.TimeUp += Show;

        public void Dispose()
            => _timeCounter.TimeUp -= Show;

        private void Show()
            => _view.Defeat.gameObject.SetActive(true);
    }
}