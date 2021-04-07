using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;

public class Reset : MonoBehaviour
{

    private GameObject Settings;
    //private SaveData saveDataScript;
    private Transform myTransform;
    private Renderer myRenderer;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        myRenderer = gameObject.GetComponent<Renderer>();
        Settings = GameObject.FindWithTag("Settings");
    }

    // Update is called once per frame
    void Update()
    {
        if (Config.resetToggled)
        {
            myRenderer.enabled = false;
        } else
        {
            myRenderer.enabled = true;
        }
    }

    void OnMouseDown()
    {
        Config.resetToggled = true;
    }
}
