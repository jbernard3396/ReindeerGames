using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donner : Ability
{

    private float timeStopLength = 1;
    private GameObject[] lazersInScene;

    private basicMovement playerScript;
    private GameObject player;

    private basicMovement basicMovementScript;

    public Donner()
    {

    }

    public override string getName()
    {
        return "Donner";
    }


    void Start()
    {
        basicMovementScript = gameObject.GetComponent<basicMovement>();
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
        playerScript.invincible = true;
        lazersInScene = GameObject.FindGameObjectsWithTag("Lazer");
        playerScript.vel.y = 2;//Mathf.Min(playerScript.vel.y, 2);

        foreach (GameObject lazer in lazersInScene)
        {
            LazerMovement lazerScript = lazer.GetComponent<LazerMovement>();
            lazerScript.timeout = timeStopLength;
        }
    }
}