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
    public static int score;
    public static bool restartAdUsed;
    public static bool characterLocked;
    public static bool allUnlocked;
    public static bool allMastered;
    public static int[] characterCosts = new int[9];
    private static float crx = 0;
    private static float clx = 0;

    

    public Config()
    {
        
    }

    static void initializeEdges()
    {
        if (crx != 0 && clx != 0)
        {
            return;
        }
        Camera cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        Vector3 viewPos = cam.WorldToViewportPoint(new Vector3(-1, -1, 0));

        float unit = .5f - viewPos.x;
        float numUnitsInScreen = 1.05f / unit;
        crx = numUnitsInScreen / 2;
        clx = -numUnitsInScreen / 2;
    }


    static public float getCrx()
    {
        initializeEdges();
        return crx;
    }

    static public float getClx()
    {
        initializeEdges();
        return clx;
    }
    static public int getCby()
    {
        initializeEdges();
        return 0;
    }
    static public int getCty()
    {
        initializeEdges();  
        return 8;
    }

    public static bool RestartAdUsed
    {
        get
        {
            return restartAdUsed;
        }
        set
        {
            restartAdUsed = value;
        }
    }

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
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

    public static bool AllMastered
    {
        get
        {
            return allMastered;
        }
        set
        {
            allMastered = value;
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

    public static int[] CharacterCosts
    {
       
        get
        {            
            return characterCosts;
        }
        set
        {
            characterCosts = value;
        }
    }

    public static bool CharacterLocked
    {
        get
        {
            return characterLocked;
        }
        set
        {
            characterLocked = value;
        }
    }
}
