using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;


public class UnlockAll : MonoBehaviour
{
    private TextMesh unlockTextMesh;

    private GameObject Settings;
    private SaveData saveDataScript;
    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        unlockTextMesh = gameObject.GetComponent<TextMesh>();

        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Config.allUnlocked = !Config.allUnlocked;
        unlockTextMesh.text = Config.allUnlocked ? "Unlocked: True" : "Unlocked: False";
    }
}
