using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vixen : Ability
{

    private basicMovement basicMovementScript;
    private GameObject realCoin;

    private basicMovement playerScript;
    private GameObject player;

    private Transform myTransform;
    private Transform theirTransform;

    private Animator anim;

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
            anim = player.GetComponent<Animator>();
        }
        myTransform = gameObject.GetComponent<Transform>();
    }

    public override void activateAbility()
    {
        startUp();

        playerScript.hasSheild = true;
        anim.SetBool("IsSheilded", true);
    }
}
