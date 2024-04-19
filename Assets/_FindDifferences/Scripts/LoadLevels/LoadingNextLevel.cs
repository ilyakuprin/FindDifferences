using System;
using _FindDifferences.Scripts.UI;
using Zenject;

namespace _FindDifferences.Scripts.LoadLevels
{
    public class LoadingNextLevel : IInitializable, IDisposable
    {
        private readonly GettingBehaviour _gettingBehaviour;
        private readonly ClickingNextLevelButton _clickingNextLevelButton;

        public LoadingNextLevel(ClickingNextLevelButton clickingNextLevelButton,
                                GettingBehaviour gettingBehaviour)
        {
            _clickingNextLevelButton = clickingNextLevelButton;
            _gettingBehaviour = gettingBehaviour;
        }

        public void Initialize()
            => _clickingNextLevelButton.Clicked += Load;

        public void Dispose()
            => _clickingNextLevelButton.Clicked -= Load;

        private void Load()
            => _gettingBehaviour.Loading.LoadNextLevel();
    }
}