using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

[System.Serializable]
public class FiveKCoins : Achievement
{

    public FiveKCoins()
    {
        numConditionMet = 0;
        numConditionNeeded = 5000;
        title = "FiveKCoins";
        unlocked = false;
    }

    override protected bool checkUnlocked()
    {
        if (numConditionMet >= numConditionNeeded)
        {
            unlocked = true;
        }
        return unlocked;
    }

    override public void update(Save saveData)
    {
        Debug.Log("Updating");
        incrementCondition(saveData.collectedCoins - numConditionMet);
    }

}