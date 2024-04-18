using System;
using Zenject;

namespace _FindDifferences.Scripts.Difference
{
    public class ClickingOnObjects : IInitializable, IDisposable
    {
        public event Action DifferenceFound;

        private readonly DifferenceView _differenceView;

        public ClickingOnObjects(DifferenceView differenceView)
        {
            _differenceView = differenceView;
        }

        public void Initialize()
        {
            for (var i = 0; i < _differenceView.CountDifference; i++)
            {
                _differenceView.GetDifference(i).Button1.onClick.AddListener(Click);
                _differenceView.GetDifference(i).Button2.onClick.AddListener(Click);
            }
        }

        public void Dispose()
        {
            for (var i = 0; i < _differenceView.CountDifference; i++)
            {
                _differenceView.GetDifference(i).Button1.onClick.RemoveListener(Click);
                _differenceView.GetDifference(i).Button2.onClick.RemoveListener(Click);
            }
        }

        private void Click()
            => DifferenceFound?.Invoke();
    }
}
