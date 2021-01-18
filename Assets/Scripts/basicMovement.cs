//TODO:J Capitilize this file

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Timers;
using System;
using static Config;
using UnityEngine.SceneManagement;




public class basicMovement : MonoBehaviour
{
    public Transform myBody;
    private Rigidbody2D rigidBody2D;
    //make this private
    public SpriteRenderer spriteRenderer;
    private Animator anim;
    private RuntimeAnimatorController animatorController;
    private GameObject Settings;
    private SaveData saveDataScript;

    private float speed;
    public Vector2 vel;
    public float g;
    public float ffriction;
    public float bfriction;
    public float dfriction;
    public float jumpStrength;
    public float physicsTimeout;

    private float jumpTimerReset = .1f;
    private float landInvincibilityTimer = .1f;
    public int jumpsLeft = 2;
    public int activesLeft = 1;
    public float invincibilityTimer = 0;
    private static System.Timers.Timer shotTimer;
    private int clx = -1;
    private int crx = 21;

    private Color spriteColor;
    private Color invColor;
    public Color sheildColor;


    private bool createLazer = false;
    public bool dead = false;
    private bool hasDeadStopped = false;
    public bool invincible = false;
    public bool hasSheild;

    public UnityEvent Collect;

    private float jumpTimer = 0f;

    [SerializeField] private GameObject lazer;
    private Ability abilityScript;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        myBody = GetComponent<Transform>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColor = spriteRenderer.color;
        sheildColor = Color.red;
        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();
        speed = 5f;

        g = 13f;
        ffriction = 500f;
        bfriction = 250f;
        dfriction = 250f;
        jumpStrength = 8f;
        physicsTimeout = 0f;

        anim = GetComponent<Animator>();
        abilityScript = Config.character;

        animatorController = abilityScript.Cont;
        anim.runtimeAnimatorController = Instantiate(animatorController) as RuntimeAnimatorController;

        vel = new Vector2(speed, 0f);
        myBody.position = new Vector3(2, 0, 0);

        shotTimer = new System.Timers.Timer(jumpTimerReset*1000);
        shotTimer.Elapsed += OnTimedEvent;
        shotTimer.Enabled = true;
        shotTimer.AutoReset = false;
        shotTimer.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(new Vector3(Config.getCrx(), Config.getCby() + .1f, 0f), new Vector3(Config.getClx(), Config.getCby() + .1f, 0f));
        if (createLazer)
        {
            fire();
        }
        myBody.Translate(vel[0] * Time.deltaTime, vel[1] * Time.deltaTime, 0);
        jumpTimer -= Time.deltaTime;
        if (physicsTimeout > 0)
        {
            physicsTimeout -= 1 * Time.deltaTime;
            if (physicsTimeout <= 0)
            {
                vel[1] = Mathf.Min(0, vel[1]);
            }
        } else
        {
            gravity();
            terminalVelocity();
            friction();
        }
        floor();
        ceil();
        wrap();
        if (dead && !hasDeadStopped)
        {
            Time.timeScale *= .01f;
            hasDeadStopped = true;

        } else if (dead)
        {
            if (Time.timeScale* 1.01f < 1) {
                Time.timeScale *= 1.01f;
            } else
            {
                Time.timeScale = 1;
            }
        }
        if (invincibilityTimer > 0)
        {
            invincible = true;
            invincibilityTimer -= 1 * Time.deltaTime;
            if (invincibilityTimer <= 0)
            {
                invincible = false;
                spriteRenderer.color = spriteColor;
            }
        }
        anim.SetBool("Jump", false);
        if (dead)
        {
            return;
        }
        bool jumpAttempt = Input.GetButtonDown("Fire1");
        if (jumpAttempt && (jumpsLeft > 0))
        {
            if (jumpTimer <= 0)
            {
                jump();
            }
        } else if (jumpAttempt && (activesLeft > 0))
        {
            if (jumpTimer <= 0)
            {
                special();
            }
        }   
    }

    public void jump()
    {
        anim.SetTrigger("Jump");
        vel[1] = jumpStrength;
        jumpsLeft -= 1;
        jumpTimer = jumpTimerReset;
        anim.ResetTrigger("Land");
        shotTimer.Start();
    }

    void special()
    {
        anim.SetTrigger("Ability");
        abilityScript.activateAbility();
        activesLeft -= 1;
        jumpTimer = jumpTimerReset;
    }

    void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        try
        {
            createLazer = true;
            shotTimer.Stop();
        } catch (Exception err) {
            Debug.Log(err);
        }
    }

    void fire()
    {
        if (myBody.position.x < Config.getCrx()-1 && myBody.position.x > Config.getClx()+1)
        {
            GameObject newLazer = Instantiate(lazer, new Vector3(myBody.position.x, myBody.position.y-.8f, -1), Quaternion.identity); //TODO:J figure out the exact right amount
        }
        createLazer = false;
    }

    void gravity()
    {
        if (myBody.position.y > 0)
        {
            vel[1] -= g * Time.deltaTime;
        }
    }

    void terminalVelocity()
    {
        if (vel[1] > jumpStrength)
        {
            vel[1] -= dfriction * Time.deltaTime;
        }
    }

    void friction()
    {
        if (vel[0] >= speed + bfriction * Time.deltaTime)
        {
            vel[0] -= bfriction * Time.deltaTime;
        } else if (vel[0] > speed)
        {
            vel[0] = speed * Time.deltaTime;
        }

        if (vel[0] <= speed - ffriction * Time.deltaTime)
        {
            vel[0] += ffriction * Time.deltaTime;
        } else if (vel[0] < speed)
        {
            vel[0] = speed;
        }
    }

    void floor()
    {
        if (myBody.position.y <= 0 && jumpsLeft < 2)
        {
            myBody.position = new Vector3(myBody.position.x, 0, 0);
            vel[1] = 0;
            jumpsLeft = 2;
            activesLeft = 1;
            if (invincible)
            { 
                invincibilityTimer = .1f;
            }
            anim.SetTrigger("Land");
        }
    }

    void ceil()
    {
        if (myBody.position.y > Config.getCty()-.5f)
        {
            myBody.position = new Vector3(myBody.position.x, Config.getCty()-.5f, 0);
            vel[1] = 0;
            invincibilityTimer = 0;
        }
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

    void OnTriggerStay2D(Collider2D other) //Helps when gift appears in player
    {
        if (other.gameObject.tag == "Coin")
        {
            Collect.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D other) //Necessary for when only touching bullet for one frame (dashing)
    {
        if (other.gameObject.tag == "Lazer")
        {
            bool isHeart = other.gameObject.GetComponent<LazerMovement>().isHeart;
            bool isDeadly = other.gameObject.GetComponent<LazerMovement>().isDeadly;
            Animator theirAnim = other.gameObject.GetComponent<Animator>();
            if (!invincible && !isHeart && isDeadly && !hasSheild)
            {
                if (!dead)
                {
                    theirAnim.SetTrigger("Splat");
                    die();
                }
            }
            else
            {

                theirAnim.SetTrigger("Splat");
                isDeadly = false;
                if(hasSheild && !isHeart)
                {
                    hasSheild = false;
                    spriteRenderer.color = spriteColor;
                }
            };
        }
    }

    private void die()
    {
        dead = true;
        saveDataScript.saveGame();
        anim.SetTrigger("Die");
    }

    void onDestroy()
    {
        SceneManager.LoadScene("GameOver");
    }
}
