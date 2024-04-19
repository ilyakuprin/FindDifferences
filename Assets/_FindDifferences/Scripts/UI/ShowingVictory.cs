using System;
using _FindDifferences.Scripts.Difference;
using Zenject;

namespace _FindDifferences.Scripts.UI
{
    public class ShowingVictory : IInitializable, IDisposable
    {
        private readonly View _view;
        private readonly CountingFound _countingFound;

        public ShowingVictory(View view,
                              CountingFound countingFound)
        {
            _view = view;
            _countingFound = countingFound;
        }

        public void Initialize()
            => _countingFound.Won += Show;

        public void Dispose()
            => _countingFound.Won -= Show;

        private void Show()
            => _view.Victory.gameObject.SetActive(true);
    }
}