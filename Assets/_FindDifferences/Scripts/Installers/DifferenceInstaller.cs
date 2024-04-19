using _FindDifferences.Scripts.Difference;
using UnityEngine;
using Zenject;

namespace _FindDifferences.Scripts.Installers
{
    public class DifferenceInstaller : MonoInstaller
    {
        [SerializeField] private View _view;
        
        public override void InstallBindings()
        {
            Container.Bind<View>().FromInstance(_view).AsSingle();
            
            Container.BindInterfacesAndSelfTo<ClickingOnObjects>().AsSingle();
            Container.BindInterfacesAndSelfTo<Fading>().AsSingle();
            Container.BindInterfacesAndSelfTo<SwitchingOffButton>().AsSingle();
            Container.BindInterfacesAndSelfTo<CountingFound>().AsSingle();
        }
    }
}