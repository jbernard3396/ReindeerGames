using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class OldSave
{
    public System.DateTime startDate = System.DateTime.Now;
    public int[] reindeerCoins = new int[9];
    public int totalCoins;

    public OldSave()
    {

    }

    public OldSave(Save newSave)
    {
        this.reindeerCoins = newSave.reindeerCoins;
        this.totalCoins = newSave.totalCoins;
    }
}