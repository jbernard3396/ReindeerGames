﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

[System.Serializable]
public class vixen_2 : Achievement
{
    public vixen_2()
    {
        numConditionNeeded = 1;
        numConditionMet = 0;
        title = "vixen_2";
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