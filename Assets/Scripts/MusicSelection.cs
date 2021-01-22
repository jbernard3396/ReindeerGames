using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelection : MonoBehaviour
{

    private TextMesh songTextMesh;
    private Transform myTransform;
    private float ReSize = 1.2f;

    [SerializeField] private AudioSource song1;
    [SerializeField] private PlayerSettings playerSettings;


    private bool songOn;


    // Start is called before the first frame update
    void Start()
    {

        myTransform = gameObject.GetComponent<Transform>();
        songTextMesh = gameObject.GetComponent<TextMesh>();

        song1.enabled = true;
        songOn = false;//PlayerPrefs.GetInt("music")==1; //TODO:J Something needs to be instantiated
        toggleSong(false);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myTransform.localScale = myTransform.localScale / ReSize;
            toggleSong();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            myTransform.localScale = myTransform.localScale / ReSize;
            toggleSong();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            myTransform.localScale = myTransform.localScale * ReSize;
        }
    }

    void OnMouseUp()
    {
        myTransform.localScale = myTransform.localScale * ReSize;
    }

    void toggleSong(bool toggle = true)
    {
        if (toggle)
        {
            songOn = !songOn;
            Debug.Log("toggling manually?");
            //playerSettings.ToggleMusic();
        }
        if (songOn)
        {
            songTextMesh.text = "Sound On";
            song1.Play();
        } else
        {
            songTextMesh.text = "Sound Off";
            song1.Stop();
        }
        
    }
}
