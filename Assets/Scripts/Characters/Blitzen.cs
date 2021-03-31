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

    private float explosionHeight;

    private float range = 2.5f;

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
        explosionHeight = explosion.GetComponent<Transform>().lossyScale.y;
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
        explosion.GetComponent<FollowTarget>().target = player;
        explosion.GetComponent<FollowTarget>().yOffset = -(explosionHeight / 3.5f);
        explosion.GetComponent<FollowTarget>().xOffset = -(explosionHeight / 25);
        Instantiate(explosion, new Vector3(myTransform.position.x, myTransform.position.y - (explosionHeight / 2), 0), Quaternion.identity);
        lazersInScene = GameObject.FindGameObjectsWithTag("Lazer");

        foreach (GameObject lazer in lazersInScene)
        {
            if (Vector3.Distance(lazer.GetComponent<Transform>().position, myTransform.position) < range)
            {
                LazerMovement lazerScript = lazer.GetComponent<LazerMovement>();
                lazerScript.towardsPlayer = true;
                lazerScript.isHeart = true; 
                lazerScript.targetBody = myTransform;
            }
        }
    }
}