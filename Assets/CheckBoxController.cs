using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxController : MonoBehaviour
{
    public string preferenceKey;
    private bool isChecked;
    private Transform myTransform;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        isChecked = PlayerPrefs.GetInt(preferenceKey) == 1;
        anim.SetBool("isChecked", isChecked);
    }

    void OnMouseDown()
    {
        //anim.SetBool("fingerPressed", true);
        //myTransform.localScale = myTransform.localScale / ReSize;


    }

    void OnMouseUp()
    {

        //reset score

        isChecked = !isChecked;
        anim.SetBool("isChecked", isChecked);
        PlayerPrefs.SetInt(preferenceKey, isChecked ? 1 : 0);
        //myTransform.localScale = myTransform.localScale * ReSize;
    }
}
