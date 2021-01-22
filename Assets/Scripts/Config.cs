using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{
    //private int crx = 21;
    //private int clx = -1;
    //private int cby = 0;
    //private int cty = 9;
    public static Ability character;
    public static int characterIndex;
    public static bool characterLocked;
    public static bool allUnlocked;

    public Config()
    {
                   
    }



    static public int getCrx()
    {
        return 21;
    }

    static public int getClx()
    {
        return -1;
    }
    static public int getCby()
    {
        return 0;
    }
    static public int getCty()
    {
        return 8;
    }

    public static bool AllUnlocked
    {
        get
        {
            return allUnlocked;
        }
        set
        {
            allUnlocked = value;
        }
    }

    public static Ability Character
    {
        get
        {
            return character;
        }
        set
        {
            character = value;
        }
    }

    public static int CharacterIndex
    {
        get
        {
            return characterIndex;
        }
        set
        {
            characterIndex = value;
        }
    }

    public static bool CharacterLocked
    {
        get
        {
            //if (allUnlocked)
            //{
            //    return true;
            //}
            return characterLocked;
        }
        set
        {
            characterLocked = value;
        }
    }
}
