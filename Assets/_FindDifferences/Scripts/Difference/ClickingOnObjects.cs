using System;
using Zenject;

namespace _FindDifferences.Scripts.Difference
{
    public class ClickingOnObjects : IInitializable, IDisposable
    {
        public event Action<int> DifferenceFoundGettingIndex;
        public event Action DifferenceFound;

        private readonly View _view;

        public ClickingOnObjects(View view)
        {
            _view = view;
        }

        public void Initialize()
        {
            for (var i = 0; i < _view.CountDifference; i++)
            {
                var index = i;
                _view.GetDifference(i).Button1.onClick.AddListener(() => Click(index));
                _view.GetDifference(i).Button2.onClick.AddListener(() => Click(index));
            }
        }

        public void Dispose()
        {
            for (var i = 0; i < _view.CountDifference; i++)
            {
                var index = i;
                _view.GetDifference(i).Button1.onClick.RemoveListener(() => Click(index));
                _view.GetDifference(i).Button2.onClick.RemoveListener(() => Click(index));
            }
        }

        private void Click(int indexButton)
        {
            DifferenceFoundGettingIndex?.Invoke(indexButton);
            DifferenceFound?.Invoke();
        } 
    }
}
