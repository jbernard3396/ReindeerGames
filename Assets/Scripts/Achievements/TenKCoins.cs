using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

[System.Serializable]
public class TenKCoins : Achievement
{
    public TenKCoins()
    {
        numConditionNeeded = 10000;
        numConditionMet = 0;
        title = "TenKCoins";
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
