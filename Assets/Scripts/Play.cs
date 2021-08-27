using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class Play : MonoBehaviour
{
    private Transform myTransform;
    private Animator anim;
    private GameObject[] lazersInScene;


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

        //reset score
        Config.score = 0;
        Config.restartAdUsed = false;
        lazersInScene = GameObject.FindGameObjectsWithTag("Lazer");

        foreach (GameObject lazer in lazersInScene)
        {
            GameObject.Destroy(lazer);
            
        }
        if (Config.characterLocked)
        {
            //play sound or something
            Debug.Log("Locked");
            return;
        }
        Debug.Log(AnalyticsEvent.GameStart());
        SceneManager.LoadScene("Game");
        //myTransform.localScale = myTransform.localScale * ReSize;
    }
}
