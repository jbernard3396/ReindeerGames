using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

[System.Serializable]
public class highScore_30 : Achievement
{
    public highScore_30()
    {
        numConditionNeeded = 30;
        numConditionMet = 0;
        title = "highScore_30";
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
        //do nothing
    }
}
