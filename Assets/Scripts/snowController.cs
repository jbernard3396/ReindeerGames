using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowController : MonoBehaviour
{
    private bool isSnowing = false;
    private bool isRaining = false;
    private float snowAmount = 0f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    { 
        if (isSnowing && snowAmount < 3)
        {
            snowAmount += .1f*Time.deltaTime; // slow this down
        } else if (!isSnowing && !isRaining && snowAmount > 0)
        {
            snowAmount -= .1f*Time.deltaTime; // slow this down
        } else if (isRaining && snowAmount > 0)
        {
            snowAmount -= .05f*Time.deltaTime; // slow this down
        }

        Debug.Log(snowAmount);
        anim.SetFloat("SnowAmmount", snowAmount);
    }

    public void setWeather(string weather)
    {
        if (weather == "rain")
        {
            isRaining = true;
            isSnowing = false;
        } else if (weather == "snow")
        {
            isSnowing = true;
            isRaining = false;
        } else
        {
            isRaining = false;
            isSnowing = false;
        }
    }
}
