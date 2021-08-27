using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

[System.Serializable]
public class OneKCoins : Achievement
{
    public OneKCoins()
    {
        numConditionNeeded = 1000;
        numConditionMet = 0;
        title = "OneKCoins";
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
