using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Ability
{
    //Dash
    private int dashSpeed;
    private basicMovement playerScript;
    private GameObject player;

    public Dash()
    {
        
    }

    void Awake()
    {
        Debug.Log("start");

    }

    public override string getName()
    {
        return "Dasher";
    }

    void startUp()
    {
        dashSpeed = 50;

        if (!playerScript)
        {
            player = GameObject.FindWithTag("Player");
            playerScript = player.GetComponent<basicMovement>();
        }
    }
    

    public override void activateAbility()
    {
        startUp();
        playerScript.vel = new Vector2(dashSpeed, 0);
        playerScript.invincible = true;
    }
}
