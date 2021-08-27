﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

[System.Serializable]
public class cupid_1 : Achievement
{
    public cupid_1()
    {
        numConditionNeeded = 1;
        numConditionMet = 0;
        title = "cupid_1";
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
