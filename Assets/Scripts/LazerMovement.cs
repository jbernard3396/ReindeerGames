using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Config;
using UnityEngine.SceneManagement;


public class LazerMovement : MonoBehaviour
{
    public Animator anim;

    private Vector3 vel = new Vector3(0, -2f, 0f);
    private float crx; 
    private float clx; 
    private float cby;
    private float cty; 
    private GameObject[] lazersInScene;

    private GameObject LazerBounceSource;
    private AudioSource LazerBounceSFX;


    public bool towardsPlayer = false;

    public float timeout;

    private SpriteRenderer spriteRenderer;

    public bool isLastLazer = true;

    public bool isHeart = false;
    public bool isDeadly = true;
    public bool onScreen = false;
    private bool wasHeart = false;

    private Transform myBody;

    public Transform targetBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        onScreen = spriteRenderer.isVisible;

        LazerBounceSource = GameObject.Find("LazerBounceSFX");
        LazerBounceSFX = LazerBounceSource.GetComponent<AudioSource>();



        crx = Config.getCrx();
        clx = Config.getClx();
        cby = Config.getCby();
        cty = Config.getCty();


        lazersInScene = GameObject.FindGameObjectsWithTag("Lazer");

        foreach (GameObject lazer in lazersInScene)
        {
            if (lazer.GetComponent<Transform>() == myBody)
            {
                //its me, do nothing
            } else
            {
                LazerMovement lazerScript = lazer.GetComponent<LazerMovement>();
                lazerScript.isLastLazer = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName != "Game")
        {
            spriteRenderer.enabled = false;
            return;
        }
        spriteRenderer.enabled = true;
        if (timeout > 0)
        {
            timeout -= 1 * Time.deltaTime;
            return;
        }
        if (towardsPlayer)
        {
            vel = (targetBody.position - myBody.position).normalized * 30;
            
        }
        myBody.Translate(vel[0] * Time.deltaTime, vel[1] * Time.deltaTime, 0); //Don't move in the z axis cause we don't wanna screw up sprite display

        if (myBody.position.y <= cby-.2f && vel[1] < 0)
        {
            anim.SetBool("Up", true);
        }
        if (myBody.position.y >= cty - .3 && vel[1] > 0)
        {
            anim.SetBool("Up", false);
        }

        if ((myBody.position.y <= cby-.58f && vel[1] < 0)|| myBody.position.y >= cty && vel[1] > 0)
        {
            bounce();
        }
        wrap();
        if (isHeart != wasHeart) //Just changed, need to change sprites
        {
            if (isHeart)
            {
                anim.SetBool("isHeart", true);
            } else
            {
                anim.SetBool("isHeart", false);
            }
            wasHeart = isHeart;
        }
    }

    void bounce()
    {
        if (LazerBounceSFX)
        {
            //LazerBounceSFX.Play();
        }
        float yPos = Mathf.Max(Mathf.Min(myBody.position.y, cty), cby-.7f);
        myBody.position = new Vector3(myBody.position.x, yPos, myBody.position.z);
        vel[1] = -vel[1];
        
    }

    void wrap() //TODO:J move this to a global helper script?
    {
        if (myBody.position.x > crx)
        {
            myBody.position = new Vector3(clx, myBody.position.y, 0);
        }
        if (myBody.position.x < clx)
        {
            myBody.position = new Vector3(crx, myBody.position.y, 0);
        }
    }

    void OnBecameInvisible()
    {
        onScreen = false;
    }

    void OnBecameVisible()
    {
        onScreen = true;
    }
}
