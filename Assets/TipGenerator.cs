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

        string[] tipsList = {"Score 25 or more coins \nwith a character to master it",
            "Tap on the screen with both \nfingers to automatically end the game",
            "You can watch an ad to continue \nplaying after your first death",
            "If you jump off screen, you \nwon't create a projectile" };
        string tip = GetTip(tipsList);
        tipTextMesh.text = "Tip: " + tip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string GetTip(string[] tipsList)
    {
        int tipInt = random.Next(0, tipsList.Length);
        return tipsList[tipInt];
    }
}
