﻿//TODO:J Capitilize this file

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Timers;
using System;
using static Config;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;





public class basicMovement : MonoBehaviour
{
    public Transform myBody;
    private Rigidbody2D rigidBody2D;
    private GameObject JumpSource;
    private AudioSource Jump;
    private GameObject SplatSource;
    private AudioSource Splat;
    private GameObject ChompBulletSource;
    private AudioSource ChompBulletSFX;

    private GameObject SheildDownSource;
    private AudioSource sheildDownSFX;

    //make this private
    public SpriteRenderer spriteRenderer;
    private Animator anim;
    private RuntimeAnimatorController animatorController;
    private GameObject Settings;
    private SaveData saveDataScript;
    private int reindeerIndex;
    private int highScore;

    private float speed;
    public Vector2 vel;
    public float g;
    public float ffriction;
    public float bfriction;
    public float dfriction;
    public float jumpStrength;
    public float physicsTimeout;

    private float jumpTimerReset = .1f;
    public int jumpsLeft = 2;
    public int activesLeft = 1;
    public float invincibilityTimer;
    private bool onScreen = true;
    private static System.Timers.Timer shotTimer;
    private float clx;
    private float crx;
    private bool doubleTapPrevention;

    private Color spriteColor;
    public Color invColor;
    public GameObject sheildDestoryed;


    private bool createLazer = false;
    public bool dead = false;
    private bool hasDeadStopped = false;
    public bool invincible = false;
    public bool hasSheild;

    public UnityEvent Collect;

    private float jumpTimer = 0f;

    [SerializeField] private GameObject lazer;
    [SerializeField] private ScoreManager scoreScript;
    private Ability abilityScript;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        myBody = GetComponent<Transform>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        JumpSource = GameObject.Find("JumpSFX");
        Jump = JumpSource.GetComponent<AudioSource>();
        SplatSource = GameObject.Find("SplatSFX");
        Splat = SplatSource.GetComponent<AudioSource>();
        ChompBulletSource = GameObject.Find("ChompBulletSFX");
        ChompBulletSFX = ChompBulletSource.GetComponent<AudioSource>();

        SheildDownSource = GameObject.Find("Sheild_Down");
        sheildDownSFX = SheildDownSource.GetComponent<AudioSource>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColor = spriteRenderer.color;
        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();
        speed = 5f;
        doubleTapPrevention = PlayerPrefs.GetInt("DoubleTapPrevention") == 1;

        clx = Config.getClx();
        crx = Config.getCrx();

        g = 13f;
        ffriction = 500f;
        bfriction = 100f;
        dfriction = 250f;
        jumpStrength = 8f;
        physicsTimeout = 0f;
        invincibilityTimer = 0f;
        if (Config.restartAdUsed)
        {
            invincibilityTimer = 3f;
        }

        anim = GetComponent<Animator>();
        abilityScript = Config.character;

        reindeerIndex = Config.characterIndex;
        highScore = saveDataScript.save.reindeerCoins[reindeerIndex];
        if (highScore >= 25 || Config.allMastered)
        {
            animatorController = abilityScript.MasteredCont;
        } else
        {
            animatorController = abilityScript.Cont;
        }
        anim.runtimeAnimatorController = Instantiate(animatorController) as RuntimeAnimatorController;

        vel = new Vector2(speed, 0f);
        //myBody.position = new Vector3(2, 0, 0);

        shotTimer = new System.Timers.Timer(jumpTimerReset*1000);
        shotTimer.Elapsed += OnTimedEvent;
        shotTimer.Enabled = true;
        shotTimer.AutoReset = false;
        shotTimer.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        abilityScript.Update();
        
        
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
            Time.timeScale *= .1f;
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
        if (invincible)
        {
            spriteRenderer.color = invColor;
        }
        if (invincibilityTimer > 0)
        {
            invincible = true;
            spriteRenderer.color = invColor;
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
            if (jumpTimer <= 0 || !doubleTapPrevention)
            {
                jump();
            }
        } else if (jumpAttempt && (activesLeft > 0))
        {
            if (jumpTimer <= 0 || !doubleTapPrevention)
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
        Jump.Play();
    }

    void special()
    {
        anim.SetTrigger("Ability");     
        abilityScript.activateAbility();
        if (invincible)
        {
            invincibilityTimer = 0;
        }
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
            if (invincible && invincibilityTimer < .1f)
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
            bool lazerOnScreen = other.gameObject.GetComponent<LazerMovement>().onScreen;

            if (!onScreen || !lazerOnScreen)
            {
                //TODO:J doesn't work very well
                return;
            }
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
                ChompBulletSFX.Play();
                isDeadly = false;
                if(hasSheild && !isHeart)
                {
                    hasSheild = false;
                    anim.SetBool("IsSheilded", false);
                    sheildDownSFX.Play();
                    Instantiate(sheildDestoryed, new Vector3(myBody.position.x, myBody.position.y, -1), Quaternion.identity);
                }
            };
        }
    }

    private void die()
    {
        Splat.Play();
        vel[0] = 0;
        vel[1] = 0;
        dead = true;
        saveDataScript.saveGame();
        anim.SetTrigger("Die");
    }

    void onDestroy()
    {
        Debug.Log(AnalyticsEvent.GameOver());
        Debug.Log(abilityScript.getName());
        Debug.Log(scoreScript.score);

        

        Debug.Log(AnalyticsEvent.Custom("Reindeer Score", new Dictionary<string, object>
        {
            {"Reindeer", abilityScript.getName() },
            {"Score", scoreScript.score }
        }));


        SceneManager.LoadScene("GameOver");
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
