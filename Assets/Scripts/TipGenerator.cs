using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // for random


public class TipGenerator : MonoBehaviour
{

    private TextMesh tipTextMesh;

    private System.Random random = new System.Random();


    // Start is called before the first frame update
    void Start()
    {

        tipTextMesh = gameObject.GetComponent<TextMesh>();

        GameObject[] tipsList = GameObject.FindGameObjectsWithTag("Tip");
        foreach(GameObject thisTip in tipsList)
        {
            thisTip.GetComponent<SpriteRenderer>().enabled = false;
        };
        GameObject tip = GetTip(tipsList);
        tip.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject GetTip(GameObject[] tipsList)
    {
        int tipInt = random.Next(0, tipsList.Length);
        return tipsList[tipInt];
    }
}
