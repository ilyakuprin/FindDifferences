using _FindDifferences.Scripts.LoadLevels;
using Zenject;

namespace _FindDifferences.Scripts.UI
{
    public class ShowingLevel : IInitializable
    {
        private const string Format = "Уровень: {0}";

        private readonly GettingBehaviour _gettingBehaviour;
        private readonly View _view;
        
        private ShowingLevel(GettingBehaviour gettingBehaviour,
                             View view)
        {
            _gettingBehaviour = gettingBehaviour;
            _view = view;
        }

        public void Initialize()
            => _view.Level.text = string.Format(Format, _gettingBehaviour.JsonIO.Data.Level);
    }
}