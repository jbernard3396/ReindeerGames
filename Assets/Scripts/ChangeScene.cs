using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class ChangeScene : MonoBehaviour
{
    public string Scene;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        if (anim)
        {
            anim.SetBool("fingerPressed", true);
        }
        //myTransform.localScale = myTransform.localScale / ReSize;


    }

    void OnMouseUp()
    {

        //reset score

        if (anim)
        {
            anim.SetBool("fingerPressed", false);
        }
       
        SceneManager.LoadScene(Scene);
        //myTransform.localScale = myTransform.localScale * ReSize;
    }
}
