using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

[System.Serializable]
public class TwoPointFiveKCoins : Achievement
{

    public TwoPointFiveKCoins()
    {
        numConditionMet = 0;
        numConditionNeeded = 2500;
        title = "TwoPointFiveKCoins";
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

