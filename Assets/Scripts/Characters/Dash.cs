using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Ability
{
    //Dash
    private int dashSpeed;
    private basicMovement playerScript;
    private GameObject player;
    private GameObject DashSource;
    private AudioSource DashSFX;

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
        dashSpeed = 30;
        if (!playerScript)
        {
            DashSource = GameObject.Find("DashSFX");
            DashSFX = DashSource.GetComponent<AudioSource>();
            player = GameObject.FindWithTag("Player");
            playerScript = player.GetComponent<basicMovement>();
           
        }
    }
    

    public override void activateAbility()
    {
        startUp();
        if (DashSFX)
        {
            DashSFX.Play();
        }
        playerScript.vel = new Vector2(dashSpeed, 0);
        playerScript.invincible = true;
    }
}
