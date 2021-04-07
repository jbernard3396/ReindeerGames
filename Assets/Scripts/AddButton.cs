using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using static Config;



public class AddButton : MonoBehaviour, IUnityAdsListener {
    //UNITY ADS
    public string myPlacementId = "rewardedVideo";

    //Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        if (Config.restartAdUsed)
        {
            GameObject.Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseUp()
    {
        Config.restartAdUsed = true;
        Debug.Log(Config.score);
        //SceneManager.LoadScene("Game"); //todoJ delete this
        ShowRewardedVideo();
        //myTransform.localScale = myTransform.localScale * ReSize;
    }

    //public void ShowInterstitialAd()
    //{
    //    // Check if UnityAds ready before calling Show method:
    //    if (Advertisement.IsReady())
    //    {
    //        Advertisement.Show();
    //    }
    //    else
    //    {
    //        Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
    //    }
    //}


    public void ShowRewardedVideo()
    {

        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(myPlacementId))
        {
            Advertisement.Show(myPlacementId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //SceneManager.LoadScene("Game");
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            Debug.Log("finished");
            SceneManager.LoadScene("Game");
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Skipped");
            // Do not reward the user for skipping the ad.
            //SceneManager.LoadScene("Game");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
            //SceneManager.LoadScene("Game");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId)
        {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // SceneManager.LoadScene("Menu");
        // Log the error.
        Debug.Log("add error");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("ad started");
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy() //Don't know whats going on here
    {
        Advertisement.RemoveListener(this);
    }


    //YODO ADS
    //void Start()
    //{

    //    if (Config.restartAdUsed)
    //    {
    //        GameObject.Destroy(gameObject);
    //    }
    //    bool isLoaded = Yodo1U3dMas.IsRewardedAdLoaded();

    //    Yodo1U3dMas.SetRewardedAdDelegate((Yodo1U3dAdEvent adEvent, Yodo1U3dAdError error) => {
    //        Debug.Log("[Yodo1 Mas] RewardVideoDelegate:" + adEvent.ToString() + "\n" + error.ToString());
    //        switch (adEvent)
    //        {
    //            case Yodo1U3dAdEvent.AdClosed:
    //                Debug.Log("[Yodo1 Mas] Reward video ad has been closed.");
    //                break;
    //            case Yodo1U3dAdEvent.AdOpened:
    //                Debug.Log("[Yodo1 Mas] Reward video ad has shown successful.");
    //                break;
    //            case Yodo1U3dAdEvent.AdError:
    //                Debug.Log("[Yodo1 Mas] Reward video ad error, " + error);
    //                break;
    //            case Yodo1U3dAdEvent.AdReward:
    //                Debug.Log("[Yodo1 Mas] Reward video ad reward, give rewards to the player.");
    //                SceneManager.LoadScene("Game");
    //                break;
    //        }
    //    });
    //}


    //void OnMouseUp()
    //{
    //    Config.restartAdUsed = true;
    //    Debug.Log(Config.score);
    //    //SceneManager.LoadScene("Game"); //todoJ delete this
    //    Yodo1U3dMas.ShowRewardedAd();
    //    //myTransform.localScale = myTransform.localScale * ReSize;
    //}


}
