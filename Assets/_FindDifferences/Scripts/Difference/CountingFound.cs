using System;
using Zenject;

namespace _FindDifferences.Scripts.Difference
{
    public class CountingFound : IInitializable, IDisposable
    {
        public event Action Won;
        
        private readonly View _view;
        private readonly Fading _fading;
        
        private int _countDifference;

        public CountingFound(View view,
                             Fading fading)
        {
            _view = view;
            _fading = fading;
        }
        
        public void Initialize()
        {
            _countDifference = _view.CountDifference;
            _fading.Faded += Reduce;
        }

        public void Dispose()
        {
            _fading.Faded -= Reduce;
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
