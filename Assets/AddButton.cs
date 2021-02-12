using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using static Config;


public class AddButton : MonoBehaviour, IUnityAdsListener { 
    public string myPlacementId = "rewardedVideo";

    // Start is called before the first frame update
    void Start()
    {
        if (Config.restartAdUsed)
        {
            GameObject.Destroy(gameObject);   
        }
        Advertisement.AddListener(this);
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
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
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
}
