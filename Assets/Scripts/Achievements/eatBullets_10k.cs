using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

[System.Serializable]
public class eatBullets_10k : Achievement
{
    public eatBullets_10k()
    {
        numConditionNeeded = 10000;
        numConditionMet = 0;
        title = "eatBullets_10k";
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
