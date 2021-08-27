using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

[System.Serializable]
public class highScore_20 : Achievement
{
    public highScore_20()
    {
        numConditionNeeded = 20;
        numConditionMet = 0;
        title = "highScore_20";
        unlocked = false;
    }

    override protected bool checkUnlocked()
    {
        Debug.Log(numConditionMet);
        Debug.Log(numConditionNeeded);
        if (numConditionMet >= numConditionNeeded)
        {
            Debug.Log("executing this??");
            if (unlocked == false)
            {
                Debug.Log("Displaying from here");
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
