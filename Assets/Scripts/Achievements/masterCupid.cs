using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class masterCupid : Achievement
{
    public masterCupid()
    {
        numConditionNeeded = 25;
        numConditionMet = 0;
        title = "masterCupid";
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

        incrementCondition(saveData.reindeerCoins[5] - numConditionMet);
    }
}
