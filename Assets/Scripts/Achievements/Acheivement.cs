using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Achievement
{
    public bool unlocked { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int numConditionNeeded { get; set; }
    public int numConditionMet { get; set; } //TODO:J Set this to protected


    public Achievement()
    {

    }

    public bool isUnlocked()
    {
        if (unlocked)
        {
            return true;
        } else
        {
            return checkUnlocked();
        }
    }

    virtual protected bool checkUnlocked()
    {
        return false;
    }


    virtual public void update(Save saveData)
    {
        return;
    }

    public void incrementCondition(int incrementNum = 1, string name = "")
    {
        if (name != "" && name != title){
            return;
        }
        numConditionMet += incrementNum;
        if(numConditionMet >= numConditionNeeded)
        {
            markAcheived(title);
            checkUnlocked();
        }
        return;
    }

    virtual public bool markAcheived(string Name)
    {
        if (title != Name)
        {
            return false;
        }
        if (unlocked == false)
        {
            displayAcheivement();
        }
        unlocked = true;
        return true;
    }

    virtual public bool upSet(string Name, int value)
    {
        if (title != Name)
        {
            return false;
        }
        Debug.Log(value);
        numConditionMet = Math.Max(numConditionMet, value);
        checkUnlocked();
        return true;
    }

    virtual public void displayAcheivement()
    {
        Debug.Log("displaying " + title);
        GameObject acheivementObject;
        string achievmentIconName = title;
        achievmentIconName = achievmentIconName.Substring(0, 1).ToLower() + achievmentIconName.Substring(1, achievmentIconName.Length - 1);
        acheivementObject = Resources.Load<GameObject>("Achievements/"+achievmentIconName);
        Debug.Log(acheivementObject);
        Sprite achievementSprite = acheivementObject.GetComponent<SpriteRenderer>().sprite;
        Sprite descriptionSprite = achievementSprite;
        if (acheivementObject.GetComponent<AchievementSelector>() != null)
        {
            descriptionSprite = acheivementObject.GetComponent<AchievementSelector>().description;
        }
        GameObject displayer;
        displayBanner displayScript;
        GameObject icon;

        displayer = GameObject.Find("AchievementDisplayer");
        displayScript = displayer.GetComponent<displayBanner>();





        displayScript.display(achievementSprite, descriptionSprite);
}

}
