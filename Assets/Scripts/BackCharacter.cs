using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCharacter : MonoBehaviour
{
    private Transform myTransform;
    private Animator anim;
    private characterSelect selector;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        anim = GetComponent<Animator>();
        selector = GameObject.Find("CharacterPanel").GetComponent<characterSelect>();
    }

    void OnMouseDown()
    {
        anim.SetBool("FingerPressed", true);
    }

    void OnMouseUp()
    {
        anim.SetBool("FingerPressed", false);
        selector.incrementCharacter(false);
    }
}
