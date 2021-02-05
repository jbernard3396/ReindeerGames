using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blitzen : Ability
{
    private GameObject[] lazersInScene;
    private Transform myTransform;

    private basicMovement playerScript;
    private GameObject player;

    private GameObject BlitzenSource;
    private AudioSource BlitzenSFX;

    private float range = 3;

    [SerializeField] private GameObject explosion;

    private basicMovement basicMovementScript;


    public Blitzen()
    {

    }

    public override string getName()
    {
        return "Blitzen";
    }

    void Start()
    {

    }

    void startUp()
    {
        if (!playerScript)
        {
            BlitzenSource = GameObject.Find("BlitzenSFX");
            BlitzenSFX = BlitzenSource.GetComponent<AudioSource>();
            player = GameObject.FindWithTag("Player");
            playerScript = player.GetComponent<basicMovement>();
        }
        myTransform = playerScript.myBody;
    }

    public override void activateAbility()
    {
        startUp();
        BlitzenSFX.Play();
        Instantiate(explosion, new Vector3(myTransform.position.x, myTransform.position.y, 0), Quaternion.identity);
        lazersInScene = GameObject.FindGameObjectsWithTag("Lazer");

        foreach (GameObject lazer in lazersInScene)
        {
            if (Vector3.Distance(lazer.GetComponent<Transform>().position, myTransform.position) < range)
            {
                LazerMovement lazerScript = lazer.GetComponent<LazerMovement>();
                lazerScript.towardsPlayer = true;
                lazerScript.isHeart = true; //TODO:J Maybe no
                lazerScript.targetBody = myTransform;
            }
        }
    }
}