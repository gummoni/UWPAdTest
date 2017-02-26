using Microsoft.Advertising.WinRT.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace App4
{
    //参考
    //https://docs.microsoft.com/ja-jp/windows/uwp/monetize/adcontrol-in-xaml-and--net

    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private InterstitialAd interstitialAd;

        public MainPage()
        {
            this.InitializeComponent();

            // Instantiate the interstitial video ad
            interstitialAd = new InterstitialAd();

            // Attach event handlers
            interstitialAd.ErrorOccurred += OnAdError;
            interstitialAd.AdReady += OnAdReady;
            interstitialAd.Cancelled += OnAdCancelled;
            interstitialAd.Completed += OnAdCompleted;
            RunInterstitialAd(null, null);
        }

        private void RunInterstitialAd(object sender, RoutedEventArgs e)
        {
            // Request an ad. When the ad is ready to show, the AdReady event will fire.
            // The application id and ad unit id are passed in here.
            // The application id and ad unit id can be obtained from Dev Center.
            // See "Monetize with Ads" at https://msdn.microsoft.com/en-us/library/windows/apps/mt170658.aspx
            interstitialAd.RequestAd(AdType.Video, "d25517cb-12d4-4699-8bdc-52040c712cab", "11389925");
            //NotifyUser("Ad requested", NotifyType.StatusMessage);
        }

        // This is an event handler for the interstitial ad. It is triggered when the interstitial ad is ready to play.
        private void OnAdReady(object sender, object e)
        {
            // The ad is ready to show; show it.
            interstitialAd.Show();
        }

        // This is an event handler for the interstitial ad. It is triggered when the interstitial ad is cancelled.
        private void OnAdCancelled(object sender, object e)
        {
            //rootPage.NotifyUser("Ad cancelled", NotifyType.StatusMessage);
        }

        // This is an event handler for the interstitial ad. It is triggered when the interstitial ad has completed playback.
        private void OnAdCompleted(object sender, object e)
        {
            //rootPage.NotifyUser("Ad completed", NotifyType.StatusMessage);
        }

        // This is an error handler for the interstitial ad.
        private void OnAdError(object sender, AdErrorEventArgs e)
        {
            //rootPage.NotifyUser($"An error occurred. {e.ErrorCode}: {e.ErrorMessage}", NotifyType.ErrorMessage);
        }

        private void OnErrorOccurred(object sender, AdErrorEventArgs e)
        {
            //rootPage.NotifyUser($"An error occurred. {e.ErrorCode}: {e.ErrorMessage}", NotifyType.ErrorMessage);
        }

        // This is an event handler for the ad control. It's invoked when the ad is refreshed.
        private void OnAdRefreshed(object sender, RoutedEventArgs e)
        {
            // We increment the ad count so that the message changes at every refresh.
            //adCount++;
            //rootPage.NotifyUser($"Advertisement #{adCount}", NotifyType.StatusMessage);
        }
    }
}
