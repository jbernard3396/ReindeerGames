using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;

public class bulletSelector : MonoBehaviour
{
    public string myColor;

    void OnMouseDown()
    {
        //anim.SetBool("fingerPressed", true);
        //myTransform.localScale = myTransform.localScale / ReSize;


    }

    void OnMouseUp()
    {

        //reset score

        //anim.SetBool("fingerPressed", false);

        PlayerPrefs.SetString("bulletColor", myColor);
        Debug.Log(myColor);
        //myTransform.localScale = myTransform.localScale * ReSize;
    }
}
