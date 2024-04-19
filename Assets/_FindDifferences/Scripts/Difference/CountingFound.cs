using System;
using Zenject;

namespace _FindDifferences.Scripts.Difference
{
    public class CountingFound : IInitializable, IDisposable
    {
        public event Action Won;
        
        private readonly View _view;
        private readonly ClickingOnObjects _clickingOnObjects;
        
        private int _countDifference;

        public CountingFound(View view,
                             ClickingOnObjects clickingOnObjects)
        {
            _view = view;
            _clickingOnObjects = clickingOnObjects;
        }
        
        public void Initialize()
        {
            _countDifference = _view.CountDifference;

            _clickingOnObjects.DifferenceFound += Reduce;
        }

        public void Dispose()
        {
            _clickingOnObjects.DifferenceFound -= Reduce;
        }

        private void Reduce()
        {
            _countDifference--;

            if (_countDifference == 0)
            {
                Won?.Invoke();
            }
        }
    }
}
