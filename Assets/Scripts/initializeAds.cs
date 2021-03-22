using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using Yodo1.MAS;

public class initializeAds : MonoBehaviour
{
    //UNITY ADDS
    ////apple id
    //string gameId = "4006508";
    ////android id
    ////string gameId = "4006509";
    //bool testMode = false;

    //void Start()
    //{
    //    Advertisement.Initialize(gameId, testMode);
    //}

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

    //YODO ads
    //Yodo1U3dMas.SetInitializeDelegate((bool success, Yodo1U3dAdError error) => {
    //    if (success){// Initialize successful
    //        Debug.Log("Initialized Ads");
    //    } else { // Initialize failure
    //        Debug.Log("Failed to initialize ads");
    //    }
    //});

   void Start()
    {
        Yodo1U3dMas.SetInitializeDelegate((bool success, Yodo1U3dAdError error) => {
            if (success)
            {// Initialize successful
                Debug.Log("Success to init ads");
            }
            else
            { // Initialize failure
                Debug.Log("Failure to init ads");
            }
        });

        Yodo1U3dMas.InitializeSdk();
    }

    
}