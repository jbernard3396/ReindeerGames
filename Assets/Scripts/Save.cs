﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Save
{
    public System.DateTime startDate = System.DateTime.Now;
    public int[] reindeerCoins = new int[9];
    public int totalCoins;
    public string bulletColor;
}