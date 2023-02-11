using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using GoogleMobileAds.Api;

public class Button_lvl : MonoBehaviour
{
    public UnityEvent OnAdLoadedEvent;
    public UnityEvent OnAdFailedToLoadEvent;
    public UnityEvent OnAdOpeningEvent;
    public UnityEvent OnAdFailedToShowEvent;
    public UnityEvent OnUserEarnedRewardEvent;
    public UnityEvent OnAdClosedEvent;
    bool start_ads_in_main;
    bool start_ads_return;
    bool start_ads_next_lvl;

    string adUnitId = "ca-app-pub-9572656335524853/9348937488";
    private InterstitialAd interstitial;
    private void Start()
    {
        RequestInterstitial();
    }
    private void RequestInterstitial()
    {
        this.interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        this.interstitial.OnAdOpening += HandleOnAdOpened;
    }
    
    public void Restart() 
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
            start_ads_return = true;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu() 
    {
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
                start_ads_in_main = true;
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        //SceneManager.LoadScene(0);
    }
    public void Next() 
    {
        if (Application.loadedLevel < 20)
        {
            if (Application.loadedLevel % 2 == 0)
            {
                if (interstitial.IsLoaded())
                {
                    interstitial.Show();
                    start_ads_next_lvl = true;
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else 
        {
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
                start_ads_next_lvl = true;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Exit_no() { GameObject.Find("Exit_trigger").SetActive(false); GameObject.Find("Fon_blur").SetActive(false); }


    public void HandleOnAdOpened(object sender, System.EventArgs args)
    {
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
    }
    public void HandleOnAdClosed(object sender, System.EventArgs args)
    {
        if (PlayerPrefs.GetFloat("Music") == 1) { GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true; }
        
        if (start_ads_next_lvl == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            start_ads_next_lvl = false;
        }
        if (start_ads_in_main == true)
        {
            SceneManager.LoadScene(0);
            start_ads_in_main = false;
        }
        if (start_ads_return == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            start_ads_return = false;
        }
        interstitial.Destroy();

    }
}
