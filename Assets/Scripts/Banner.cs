using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class Banner : MonoBehaviour
{
    // Start is called before the first frame update
    string adUnitId = "ca-app-pub-9572656335524853/8231296938";
    private BannerView bannerView;
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.LoadBanner();
        //LoadBanner();
    }
    private void LoadBanner()
    {
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
        //IronSource.Agent.loadBanner(IronSourceBannerSize.SMART, IronSourceBannerPosition.BOTTOM);
    }
     private void Awake()
     {
        //bannerView.Destroy();
        // IronSource.Agent.init("136f40919");
         //IronSource.Agent.init("136f40919", IronSourceAdUnits.BANNER);
     }
}
