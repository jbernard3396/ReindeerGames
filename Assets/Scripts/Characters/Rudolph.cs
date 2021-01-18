using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rudolph : Ability
{
    //Rudolph
    private float invincibleTimer = .5f;

    private basicMovement playerScript;
    private GameObject player;

    public Rudolph()
    {

    }

    public override string getName()
    {
        return "Rudolph";
    }


    void Start()
    {
    }

    void startUp()
    {
        if (!playerScript)
        {
            player = GameObject.FindWithTag("Player");
            playerScript = player.GetComponent<basicMovement>();
        }
    }

    public override void activateAbility()
    {
        startUp();
        playerScript.activesLeft = 2;
        playerScript.jumpsLeft = 1;
        playerScript.jump();
        playerScript.invincibilityTimer = invincibleTimer;
    }
}
