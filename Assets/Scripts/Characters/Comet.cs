using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : Ability
{
    //Dash
    private int slamSpeed = -30;
    private basicMovement playerScript;
    private GameObject player;
    private GameObject CometSource;
    private AudioSource CometSFX;

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
            CometSource = GameObject.Find("CometSFX");
            CometSFX = CometSource.GetComponent<AudioSource>();
            player = GameObject.FindWithTag("Player");
            playerScript = player.GetComponent<basicMovement>();
        }
    }

    public override void activateAbility()
    {
        startUp();
        CometSFX.Play();
        playerScript.vel = new Vector2(playerScript.vel[0], slamSpeed);
        playerScript.invincible = true;
    }
}
