using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vixen : Ability
{

    private int dashSpeed = 50;
    private basicMovement basicMovementScript;
    private GameObject realCoin;

    private basicMovement playerScript;
    private GameObject player;

    private Transform myTransform;
    private Transform theirTransform;

    private float physicsTimeout = .025f;

    public Vixen()
    {

    }

    public override string getName()
    {
        return "Vixen";
    }

    void startUp()
    {
        if (!playerScript)
        {
            player = GameObject.FindWithTag("Player");
            playerScript = player.GetComponent<basicMovement>();
        }
        myTransform = gameObject.GetComponent<Transform>();
    }

    public override void activateAbility()
    {
        startUp();

        playerScript.hasSheild = true;
        playerScript.spriteRenderer.color = playerScript.sheildColor;
    }
}
