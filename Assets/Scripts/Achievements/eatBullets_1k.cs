using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

[System.Serializable]
public class eatBullets_1k : Achievement
{
    public eatBullets_1k()
    {
        numConditionNeeded = 1000;
        numConditionMet = 0;
        title = "eatBullets_1k";
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
        //do nothing
    }
}
