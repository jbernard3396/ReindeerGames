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
    public AudioClip thunderClip;
    private GameObject SnowStormSource;
    private AudioSource SnowSFX;
    private float ogVolume;
    private float ogSnowVolume;

    private bool isRaining;
    private bool isSnowing;
    private bool isSunny;
    private int chanceToChange = 3000;
    private int minimumStormTime = 10;
    private float timeSinceLastStorm = 0;
    private int chanceToThunder = 1000;
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
        SnowStormSource = GameObject.Find("ColdWind");
        SnowSFX = SnowStormSource.GetComponent<AudioSource>();
        ogVolume = (float)RainSFX.volume;
        ogSnowVolume = (float)SnowSFX.volume;


        snow1 = GameObject.Find("snow1").GetComponent<snowController>();
        snow2 = GameObject.Find("snow2").GetComponent<snowController>();


        isRaining = false;
    }

    // Update is called once per frame
    void Update()
    {
        continueWeather();
        if (timeSinceLastStorm < minimumStormTime)
        {
            timeSinceLastStorm += Time.deltaTime;
        } else if (random.Next(chanceToChange) == 1 && PlayerPrefs.GetString("weatherStyle") == "All")
        {
            selectNewWeather();
            timeSinceLastStorm = 0;
            startNewWeather();
        }
        if (PlayerPrefs.GetString("weatherStyle") != "All")
        {
            getWeatherFromPrefs();
        } 
    }

    private void continueWeather()
    {
        if (isRaining)
        {
            SnowSFX.Stop();
            snow1.setWeather("rain");
            snow2.setWeather("rain");
            if (random.Next(chanceToThunder) == 1)
            {
                ThunderSFX.PlayOneShot(thunderClip, 1f);
                anim.SetTrigger("Thunder");
            }
        }
        else if (isSunny)
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
            if (SnowSFX.volume > 0)
            {
                SnowSFX.volume -= .1f * Time.deltaTime;
            }
            else
            {
                SnowSFX.Stop();
            }
        }
        else if (isSnowing)
        {

            snow1.setWeather("snow");
            snow2.setWeather("snow");
            RainSFX.Stop();
            Debug.Log("stop rain 1");
        }
    }

    private void getWeatherFromPrefs()
    {
        Debug.Log(PlayerPrefs.GetString("weatherStyle"));
        Debug.Log("rain: " + isRaining);
        Debug.Log("snow: " + isSnowing);
        Debug.Log("sun: " + isSunny);
        if (PlayerPrefs.GetString("weatherStyle") == "Sun" && isSunny == false)
        {
            Debug.Log("truning sun on");
            isSunny = true;
            isRaining = false;
            isSnowing = false;
            startNewWeather();
        }
        if (PlayerPrefs.GetString("weatherStyle") == "Rain" && isRaining == false)
        {
            Debug.Log("truning rain on");
            isSunny = false;
            isRaining = true;
            isSnowing = false;
            startNewWeather();
        }
        if (PlayerPrefs.GetString("weatherStyle") == "Snow" && isSnowing == false)
        {
            Debug.Log("truning snow on");
            isSunny = false;
            isRaining = false;
            isSnowing = true;
            startNewWeather();
        }
    }

    private void startNewWeather()
    {
        anim.SetBool("isRaining", isRaining);
        anim.SetBool("isSnowing", isSnowing);
        if (isRaining)
        {

            ThunderSFX.Play();
            RainSFX.Stop();
            Debug.Log("stop rain 2");
            RainSFX.volume = (float)ogVolume;
            RainSFX.Play();
        }
        if (isSnowing)
        {
            SnowSFX.Stop();
            SnowSFX.volume = (float)ogSnowVolume;
            SnowSFX.Play();
        }
    }

    private void selectNewWeather()
    {
        if (!isSunny)
        { //now it is
            isSunny = true;
            isRaining = false;
            isSnowing = false;
        }
        else
        { //already sunny, pick a weather
            if (random.Next(2) != 1)
            {
                isSunny = false;
                isRaining = false;
                isSnowing = true;
            }
            else
            {
                isSunny = false;
                isRaining = true;
                isSnowing = false;
            }
        }
    }
}
