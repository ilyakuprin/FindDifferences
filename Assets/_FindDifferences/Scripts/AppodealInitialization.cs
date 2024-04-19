using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppodealInitialization : MonoBehaviour
{
    private void Awake()
    {
        var adTypes = AppodealAdType.Interstitial;
        var appKey = "adf0f983389c11ca0cb5f82e9f610c8244e750718116de02";
        AppodealCallbacks.Sdk.OnInitialized += OnInitializationFinished;
        Appodeal.Initialize(appKey, adTypes);
    }

    private static void OnInitializationFinished(object sender, SdkInitializedEventArgs e)
    {
    }

    public void ShowInterstitial()
    {
        if (Appodeal.IsLoaded(AppodealAdType.Interstitial) &&
            Appodeal.CanShow(AppodealAdType.Interstitial, "default") &&
            !Appodeal.IsPrecache(AppodealAdType.Interstitial))
        {
            Appodeal.Show(AppodealShowStyle.Interstitial);
        }
        else if (!Appodeal.IsAutoCacheEnabled(AppodealAdType.Interstitial))
        {
            Appodeal.Cache(AppodealAdType.Interstitial);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}