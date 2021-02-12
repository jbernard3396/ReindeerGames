using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Timers;

public class Donner : Ability
{

    private float timeStopLength = 1;
    //private float timer = 0;
    //private bool timeStopped = false;
    private bool timerOver = false;
    private GameObject[] lazersInScene;

    private basicMovement playerScript;
    private GameObject player;

    private basicMovement basicMovementScript;

    private GameObject TimeStopSource;
    private AudioSource TimeStopSFX;

    private GameObject TimeStartSource;
    private AudioSource TimeStartSFX;

    private static System.Timers.Timer TimeStopTimer;




    public Donner()
    {

    }

    public override string getName()
    {
        return "Donner";
    }


    void Start()
    {
        basicMovementScript = gameObject.GetComponent<basicMovement>();
    }

    public override void Update()
    {
        if (timerOver)
        {
            timerOver = false;
            TimeStartSFX.Play();
            TimeStopTimer.Stop();
        }
    }

    void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        try
        {
            timerOver = true;
        }
        catch (Exception err)
        {
            Debug.Log(err);
        }
    }

    void startUp()
    {
        if (!playerScript)
        {
            TimeStopSource = GameObject.Find("Time_stopSFX");
            TimeStopSFX = TimeStopSource.GetComponent<AudioSource>();

            TimeStartSource = GameObject.Find("Time_startSFX");
            TimeStartSFX = TimeStartSource.GetComponent<AudioSource>();

            player = GameObject.FindWithTag("Player");
            playerScript = player.GetComponent<basicMovement>();


            TimeStopTimer = new System.Timers.Timer(timeStopLength * 1000);
            TimeStopTimer.Elapsed += OnTimedEvent;
            TimeStopTimer.Enabled = true;
            TimeStopTimer.AutoReset = false;
            TimeStopTimer.Stop();
        }
    }

    public override void activateAbility()
    {
        startUp();
        TimeStopSFX.Play();
        TimeStopTimer.Start();
        //timeStopped = true;
        playerScript.invincible = true;
        lazersInScene = GameObject.FindGameObjectsWithTag("Lazer");
        playerScript.vel.y = 2;//Mathf.Min(playerScript.vel.y, 2);

        foreach (GameObject lazer in lazersInScene)
        {
            LazerMovement lazerScript = lazer.GetComponent<LazerMovement>();
            lazerScript.timeout = timeStopLength;
        }
    }
}