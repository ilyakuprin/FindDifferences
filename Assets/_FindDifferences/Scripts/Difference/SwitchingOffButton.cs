using System;
using Zenject;

namespace _FindDifferences.Scripts.Difference
{
    public class SwitchingOffButton : IInitializable, IDisposable
    {
        private readonly ClickingOnObjects _clickingOnObjects;
        private readonly View _view;

        public SwitchingOffButton(ClickingOnObjects clickingOnObjects,
                                  View view)
        {
            _clickingOnObjects = clickingOnObjects;
            _view = view;
        }
        
        public void Initialize()
            => _clickingOnObjects.DifferenceFoundGettingIndex += Switch;

        public void Dispose()
            => _clickingOnObjects.DifferenceFoundGettingIndex -= Switch;

        private void Switch(int indexDifference)
        {
            _view.GetDifference(indexDifference).Button1.interactable = false;
            _view.GetDifference(indexDifference).Button2.interactable = false;
        }
    }
}