﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

[System.Serializable]
public class unlockAll : Achievement
{
    public unlockAll()
    {
        numConditionNeeded = 1;
        numConditionMet = 0;
        title = "unlockAll";
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