using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using static Achievement;



[System.Serializable]
public class Save
{
    public System.DateTime startDate = System.DateTime.Now;
    public int[] reindeerCoins = new int[9];
    public int totalCoins;
    public int collectedCoins;

    public Save()
    {

    }

    public Save(OldSave partialSave)
    {
        this.startDate = partialSave.startDate;
        this.reindeerCoins = partialSave.reindeerCoins;
        this.totalCoins = partialSave.totalCoins;
        this.collectedCoins = partialSave.totalCoins; //At least this many
        initializeAchievements();
    }

    public List<Achievement> achievements;

    [OnDeserializing]
    private void initializeExtraDataStructures(StreamingContext sc)
    {
        initializeAchievements();
    }

    public void initializeAchievements()
    {
            achievements = new List<Achievement>() { new oneHundredCoins(), new OneKCoins(), new TwoPointFiveKCoins(), new FiveKCoins(), new TenKCoins(), new masterDasher(), new masterDancer(), new masterPrancer(), new masterVixen(), new masterComet(), new masterCupid(), new masterDonner(), new masterBlitzen(), new masterRudolph(), new highScore_20(), new highScore_30(), new highScore_50(), new eatBullets_100(), new eatBullets_1k(), new eatBullets_10k(), new ads_100(), new dasher_1(), new dancer_1(), new dasher_2(), new dancer_2(), new prancer_1(), new prancer_2(), new vixen_1(), new comet_1(), new vixen_2(), new comet_2(), new cupid_1(), new cupid_2(), new donner_1(), new donner_2(), new blitzen_1(), new rudolph_1(), new blitzen_2(), new rudolph_2(), new SoClose(), new diveBomb(), new hangingOn(), new hs_100(), new hs_250(), new hs_500(), new unlockAll(), new masterAll() };
    }
}
