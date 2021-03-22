using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;

public class SelectorActivator : MonoBehaviour
{
    public string myColor;
    private Renderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("bulletColor") == myColor)
        {
            myRenderer.enabled = true;
        } else
        {
            myRenderer.enabled = false;
        }
    }
}
