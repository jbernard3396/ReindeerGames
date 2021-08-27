using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class masterDasher : Achievement
{
    public masterDasher()
    {
        numConditionNeeded = 25;
        numConditionMet = 0;
        title = "masterDasher";
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
        incrementCondition(saveData.reindeerCoins[0] - numConditionMet);
    }
}
