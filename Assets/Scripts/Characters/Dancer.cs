using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : Ability
{
    private int danceSpeed = -50;
    private basicMovement playerScript;
    private GameObject player;
    


    public Dancer()
    {

    }

    public override string getName()
    {
        return "Dancer";
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
        playerScript.vel = new Vector2(danceSpeed, 0);
        playerScript.invincible = true;
    }
}
