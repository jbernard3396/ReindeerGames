using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupid : Ability
{
    private basicMovement basicMovementScript;
    private GameObject[] lazersInScene;
    private basicMovement playerScript;
    private GameObject player;
    private GameObject ConvertHeartSource;
    private AudioSource ConvertHeartSFX;


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
            ConvertHeartSource = GameObject.Find("turn_hearts");
            ConvertHeartSFX = ConvertHeartSource.GetComponent<AudioSource>();
            player = GameObject.FindWithTag("Player");
            playerScript = player.GetComponent<basicMovement>();
        }
    }

    public override void activateAbility()
    {
        startUp();
        if (ConvertHeartSFX)
        {
            ConvertHeartSFX.Play();
        }
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
