using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Replay : MonoBehaviour
{
    private Transform myTransform;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Dance?        
    }

    void OnMouseDown()
    {
        anim.SetBool("fingerPressed", true);
        //myTransform.localScale = myTransform.localScale / ReSize;


    }

    void OnMouseUp()
    {
        anim.SetBool("fingerPressed", false);
        if (Config.characterLocked)
        {
            //play sound or something
            Debug.Log("Locked");
            return;
        }
        SceneManager.LoadScene("menu");
        //myTransform.localScale = myTransform.localScale * ReSize;
    }
}
