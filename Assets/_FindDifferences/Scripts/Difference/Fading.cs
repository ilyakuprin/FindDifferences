using System;
using DG.Tweening;
using Zenject;

namespace _FindDifferences.Scripts.Difference
{
    public class Fading : IInitializable, IDisposable
    {
        public event Action Faded;
        
        private const float EndValueFade = 0f;
        private const float TimeFade = 1f;
        
        private readonly ClickingOnObjects _clickingOnObjects;
        private readonly View _view;

        public Fading(ClickingOnObjects clickingOnObjects,
                      View view)
        {
            _clickingOnObjects = clickingOnObjects;
            _view = view;
        }

        public void Initialize()
            => _clickingOnObjects.DifferenceFoundGettingIndex += Fade;

        public void Dispose()
            => _clickingOnObjects.DifferenceFoundGettingIndex -= Fade;

        private void Fade(int indexDifference)
        {
            _view.GetDifference(indexDifference).Image2.DOFade(EndValueFade, TimeFade)
                .OnKill(() => Faded?.Invoke());
        }
    }
}