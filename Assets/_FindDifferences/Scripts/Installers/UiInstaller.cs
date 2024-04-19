using UnityEngine;
using Zenject;
using _FindDifferences.Scripts.UI;

namespace _FindDifferences.Scripts.Installers
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private View _view;

        public override void InstallBindings()
        {
            Container.Bind<View>().FromInstance(_view).AsSingle();
            
            Container.BindInterfacesAndSelfTo<ShowingDefeat>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingVictory>().AsSingle();
        }
    }
}