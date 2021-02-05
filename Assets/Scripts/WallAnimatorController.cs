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
    private int chanceToChange = 10000;
    private int minimumStormTime = 15;
    private float timeSinceLastStorm = 0;
    private int chanceToThunder = 3000;
    private System.Random random = new System.Random();
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();

        RainSource = GameObject.Find("RainSFX");
        RainSFX = RainSource.GetComponent<AudioSource>();
        ThunderSource = GameObject.Find("ThunderSFX");
        ThunderSFX = ThunderSource.GetComponent<AudioSource>();
        ogVolume = (float)RainSFX.volume;



        isRaining = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRaining)
        {
            if (random.Next(chanceToThunder) == 1)
            {
                ThunderSFX.Play();
                anim.SetTrigger("Thunder");
            }
        } else
        {
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
            isRaining = !isRaining;
            timeSinceLastStorm = 0;
            anim.SetBool("isRaining", isRaining);
            if (isRaining)
            {
                ThunderSFX.Play();
                RainSFX.Stop();
                RainSFX.volume = (float)ogVolume;
                RainSFX.Play();
            }
        }


    }
}
