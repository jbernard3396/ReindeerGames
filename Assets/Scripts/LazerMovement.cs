using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Config;

public class LazerMovement : MonoBehaviour
{
    public Animator anim;

    private Vector3 vel = new Vector3(0, -2f, 0f);
    private int crx = Config.getCrx();
    private int clx = Config.getClx();
    private int cby = Config.getCby();
    private int cty = Config.getCty();
    private GameObject[] lazersInScene;

    public bool towardsPlayer = false;

    public float timeout;

    private SpriteRenderer spriteRenderer;

    public bool isLastLazer = true;

    public bool isHeart = false;
    public bool isDeadly = true;
    private bool wasHeart = false;

    private Transform myBody;

    public Transform targetBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


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

        if (myBody.position.y <= cby-.58f || myBody.position.y >= cty)
        {
            bounce();
        }
        wrap();
        if (isHeart != wasHeart) //Just changed, need to change sprites
        {
            if (isHeart)
            {
                spriteRenderer.color = new Color(255/255, 30/255, 255/255);
            } else
            {
                spriteRenderer.color = new Color(0/255, 255/255, 23/255);
            }
            wasHeart = isHeart;
        }
    }

    void bounce()
    {
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
}
