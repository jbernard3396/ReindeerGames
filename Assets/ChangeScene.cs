using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class ChangeScene : MonoBehaviour
{
    public string Scene;

    void OnMouseDown()
    {
        //anim.SetBool("fingerPressed", true);
        //myTransform.localScale = myTransform.localScale / ReSize;


    }

    void OnMouseUp()
    {

        //reset score
 

        //anim.SetBool("fingerPressed", false);
       
        SceneManager.LoadScene(Scene);
        //myTransform.localScale = myTransform.localScale * ReSize;
    }
}
