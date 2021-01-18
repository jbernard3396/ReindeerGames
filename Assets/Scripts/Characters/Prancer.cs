using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Prancer : Ability
{
    //Dash
    private float upSpeed;
    private basicMovement playerScript;
    private GameObject player;
    private Animator anim;

    public Prancer()
    {
    }

    void Start()
    {

    }

    public override string getName()
    {
        return "Prancer";
    }


    void startUp()
    {
        if (!playerScript)
        {
            player = GameObject.FindWithTag("Player");
            playerScript = player.GetComponent<basicMovement>();
            anim = player.GetComponent<Animator>();
        }
        upSpeed = playerScript.jumpStrength;
    }

    public override void activateAbility()
    {
        startUp();
        playerScript.vel = new Vector2(-1* playerScript.vel[0], upSpeed);
        playerScript.ffriction = 0;
        playerScript.bfriction = 0;
        playerScript.invincible = true;
    }
}
