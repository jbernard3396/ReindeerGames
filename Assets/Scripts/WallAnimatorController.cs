using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // for random

public class WallAnimatorController : MonoBehaviour
{
    private Animator anim;

    private GameObject RainSource;
    private AudioSource RainSFX;
    private GameObject ThunderSource;
    private AudioSource ThunderSFX;
    private float ogVolume;

    private bool isRaining;
    private bool isSnowing;
    private bool isSunny;
    private int chanceToChange = 5000;
    private int minimumStormTime = 15;
    private float timeSinceLastStorm = 0;
    private int chanceToThunder = 3000;
    private System.Random random = new System.Random();

    public snowController snow1;
    public snowController snow2;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();

        RainSource = GameObject.Find("RainSFX");
        RainSFX = RainSource.GetComponent<AudioSource>();
        ThunderSource = GameObject.Find("ThunderSFX");
        ThunderSFX = ThunderSource.GetComponent<AudioSource>();
        ogVolume = (float)RainSFX.volume;

        snow1 = GameObject.Find("snow1").GetComponent<snowController>();
        snow2 = GameObject.Find("snow2").GetComponent<snowController>();


        isRaining = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRaining)
        {
            snow1.setWeather("rain");
            snow2.setWeather("rain");
            if (random.Next(chanceToThunder) == 1)
            {
                ThunderSFX.Play();
                anim.SetTrigger("Thunder");
            }
        } else if (isSunny)
        {
            snow1.setWeather("sunny");
            snow2.setWeather("sunny");
            if (RainSFX.volume > 0)
            {
                RainSFX.volume -= .1f * Time.deltaTime;
            }
            else
            {
                RainSFX.Stop();
            }
        } else if(isSnowing)
        {

       
            snow1.setWeather("snow");   
            snow2.setWeather("snow");
            if (RainSFX.volume > 0)
            {
                RainSFX.volume -= .1f*Time.deltaTime;
            }
            else
            {
                RainSFX.Stop();
            }
        }

        if (timeSinceLastStorm < minimumStormTime)
        {
            timeSinceLastStorm += Time.deltaTime;
        } else if (random.Next(chanceToChange) == 1) {
            if (!isSunny)
            { //now it is
                isSunny = true;
                isRaining = false;
                isSnowing = false;
            } else
            { //already sunny, pick a weather
                if(random.Next(2) != 1)
                {
                    Debug.Log("Snow now");
                    isSunny = false;
                    isRaining = false;
                    isSnowing = true;
                } else
                {
                    Debug.Log("rain now");
                    isSunny = false;
                    isRaining = true;
                    isSnowing = false;
                }
            }
            timeSinceLastStorm = 0;
            anim.SetBool("isRaining", isRaining);
            anim.SetBool("isSnowing", isSnowing);
            if (isRaining)
            {
                ThunderSFX.Play();
                RainSFX.Stop();
                RainSFX.volume = (float)ogVolume;
                RainSFX.Play();
            }
            if (isSnowing)
            {
                //you know play snow sounds;
            }
        }


    }
}
