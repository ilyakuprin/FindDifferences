using _FindDifferences.Scripts.AppodealSdk;
using _FindDifferences.Scripts.LoadLevels;
using UnityEngine;
using Zenject;
using _FindDifferences.Scripts.UI;

namespace _FindDifferences.Scripts.Installers
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private View _view;
        [SerializeField] private GettingBehaviour _gettingBehaviour;

        public override void InstallBindings()
        {
            Container.Bind<View>().FromInstance(_view).AsSingle();
            Container.Bind<GettingBehaviour>().FromInstance(_gettingBehaviour).AsSingle();
            
            Container.BindInterfacesAndSelfTo<ShowingDefeat>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingVictory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingLevel>().AsSingle();
            Container.BindInterfacesAndSelfTo<ClickingNextLevelButton>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingAd>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingNextLevel>().AsSingle();
        }
    }
}