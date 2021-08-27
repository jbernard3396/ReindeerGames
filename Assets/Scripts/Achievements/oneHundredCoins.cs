using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

[System.Serializable]
public class oneHundredCoins : Achievement
{

    public oneHundredCoins()
    {
        numConditionMet = 0;
        numConditionNeeded = 100;
        title = "OneHundredCoins";
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
        incrementCondition(saveData.collectedCoins - numConditionMet);
    }

}

