using _FindDifferences.Scripts.Timer;
using UnityEngine;
using Zenject;

namespace _FindDifferences.Scripts.Installers
{
    public class TimerInstaller : MonoInstaller
    {
        [SerializeField] private View _view;

        public override void InstallBindings()
        {
            Container.Bind<View>().FromInstance(_view).AsSingle();
            
            Container.BindInterfacesAndSelfTo<Showing>().AsSingle();
            Container.BindInterfacesAndSelfTo<TimeCounter>().AsSingle();
            Container.BindInterfacesAndSelfTo<StoppingTimer>().AsSingle();
        }
    }
}