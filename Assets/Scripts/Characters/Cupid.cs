using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupid : Ability
{
    private basicMovement basicMovementScript;
    private GameObject[] lazersInScene;
    private basicMovement playerScript;
    private GameObject player;

    public Cupid()
    {

    }

    void Start()
    {
    }

    public override string getName()
    {
        return "Cupid";
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
        lazersInScene = GameObject.FindGameObjectsWithTag("Lazer");

        foreach (GameObject lazer in lazersInScene)
        {
            LazerMovement lazerScript = lazer.GetComponent<LazerMovement>();
            if (!lazerScript.isLastLazer)
            {
                lazerScript.isHeart = !lazerScript.isHeart;
            }
        }
    }
}
