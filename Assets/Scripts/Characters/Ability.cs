using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{

    //public basicMovement playerScript;
    //public GameObject player;
    //protected int testInt = 1;
    public RuntimeAnimatorController Cont;


    public Ability()
	{
        
    }

    //protected void Awake()
    //{
    //    testInt = 2;
    //    Debug.Log("start");
    //    player = GameObject.FindWithTag("Player");
    //    playerScript = player.GetComponent<basicMovement>();
    //    Debug.Log(playerScript);
    //    startUp();
    //}

    public virtual void activateAbility()
    {
        Debug.Log("ability");
    }

    public virtual string getName()
    {
        return "Default";
    }
}
