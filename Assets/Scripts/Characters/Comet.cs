using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : Ability
{
    //Dash
    private int slamSpeed = -30;
    private basicMovement playerScript;
    private GameObject player;

    public Comet()
    {

    }

    void Start()
    {
    }

    public override string getName()
    {
        return "Comet";
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
        playerScript.vel = new Vector2(playerScript.vel[0], slamSpeed);
        playerScript.invincible = true;
    }
}
