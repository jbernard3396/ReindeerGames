using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    private GameObject Settings;
    private SaveData saveDataScript;
    private float ReSize = 1.2f;
    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        myTransform.localScale = myTransform.localScale / ReSize;
        saveDataScript.deleteSave();
    }
}
