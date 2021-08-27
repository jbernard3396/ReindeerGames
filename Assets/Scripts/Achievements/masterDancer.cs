using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class masterDancer : Achievement
{
    public masterDancer()
    {
        numConditionNeeded = 25;
        numConditionMet = 0;
        title = "masterDancer";
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
        incrementCondition(saveData.reindeerCoins[1] - numConditionMet);
    }
}
