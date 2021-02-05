using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;


public class MasterAll : MonoBehaviour
{
    private TextMesh masterTextMesh;

    private GameObject Settings;
    private SaveData saveDataScript;
    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        masterTextMesh = gameObject.GetComponent<TextMesh>();

        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();
        masterTextMesh.text = Config.allMastered ? "Mastered: True" : "Mastered: False";


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Config.allMastered = !Config.allMastered;
        masterTextMesh.text = Config.allMastered ? "Mastered: True" : "Mastered: False";
    }
}
