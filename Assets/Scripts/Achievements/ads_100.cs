﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

[System.Serializable]
public class ads_100 : Achievement
{
    public ads_100()
    {
        numConditionNeeded = 100;
        numConditionMet = 0;
        title = "ads_100";
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
