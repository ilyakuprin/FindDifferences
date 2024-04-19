using System;
using Zenject;

namespace _FindDifferences.Scripts.UI
{
    public class ClickingNextLevelButton : IInitializable, IDisposable
    {
        public event Action Clicked;
        
        private readonly View _view; 
        
        public ClickingNextLevelButton(View view)
        {
            _view = view;
        }
        
        public void Initialize()
        {
            _view.VictoryButton.onClick.AddListener(Click);
            _view.DefeatButton.onClick.AddListener(Click);
        }

        public void Dispose()
        {
            _view.VictoryButton.onClick.RemoveListener(Click);
            _view.DefeatButton.onClick.RemoveListener(Click);
        }

        private void Click()
            => Clicked?.Invoke();
    }
}