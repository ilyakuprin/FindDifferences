using System;
using _FindDifferences.Scripts.UI;
//using AppodealStack.Monetization.Api;
//using AppodealStack.Monetization.Common;
using Zenject;

namespace _FindDifferences.Scripts.AppodealSdk
{
    public class ShowingAd : IInitializable, IDisposable
    {
        private readonly ClickingNextLevelButton _clickingNextLevelButton;

        public ShowingAd(ClickingNextLevelButton clickingNextLevelButton)
        {
            _clickingNextLevelButton = clickingNextLevelButton;
        }

        public void Initialize()
            => _clickingNextLevelButton.Clicked += ShowInterstitial;

        public void Dispose()
            => _clickingNextLevelButton.Clicked -= ShowInterstitial;

        private static void ShowInterstitial()
        {
            /*if (Appodeal.IsLoaded(AppodealAdType.Interstitial) &&
                Appodeal.CanShow(AppodealAdType.Interstitial) &&
                !Appodeal.IsPrecache(AppodealAdType.Interstitial))
            {
                Appodeal.Show(AppodealShowStyle.Interstitial);
            }
            else if (!Appodeal.IsAutoCacheEnabled(AppodealAdType.Interstitial))
            {
                Appodeal.Cache(AppodealAdType.Interstitial);
            }*/
        }
    }
}