using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class masterDonner : Achievement
{
    public masterDonner()
    {
        numConditionNeeded = 25;
        numConditionMet = 0;
        title = "masterDonner";
        unlocked = false;
    }

    override protected bool checkUnlocked()
    {
        if (numConditionMet >= numConditionNeeded)
        {
            if (unlocked == false)
            {
                displayAcheivement();
            }
            unlocked = true;
        }
        return unlocked;
    }

    override public void update(Save saveData)
    { 
        incrementCondition(saveData.reindeerCoins[6] - numConditionMet);
    }
}
