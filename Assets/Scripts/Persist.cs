using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persist : MonoBehaviour
{
    public void Awake()
    {      
        DontDestroyOnLoad(this);
    }
}
