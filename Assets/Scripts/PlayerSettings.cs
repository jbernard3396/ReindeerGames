using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class PlayerSettings : MonoBehaviour
{
    public bool songOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Awake()
    {
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            songOn = true;
            PlayerPrefs.Save();
        }
        else
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                songOn = false;
            }
            else
            {
                songOn = true;
            }
        }

        if (!PlayerPrefs.HasKey("DoubleTapPrevention"))
        {
            PlayerPrefs.SetInt("DoubleTapPrevention", 1);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("bulletColor"))
        {
            PlayerPrefs.SetString("bulletColor", "Red");
            PlayerPrefs.Save();
        }        
    }

    public void ToggleMusic()
    {
        if (!songOn)
        {
            PlayerPrefs.SetInt("music", 1);
            songOn = true;
        }
        else
        {
            Debug.Log("turn music off");
            PlayerPrefs.SetInt("music", 0);
            songOn = false;
        }
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
