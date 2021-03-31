using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetConfimation : MonoBehaviour
{

    private GameObject Settings;
    private SaveData saveDataScript;
    private Transform myTransform;
    private Renderer myRenderer;

    private GameObject characterSelector;
    private characterSelect characterSelectScript;

    public bool confirm;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        myRenderer = gameObject.GetComponent<Renderer>();
        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();

        characterSelector = GameObject.Find("CharacterPanel");
        characterSelectScript = characterSelector.GetComponent<characterSelect>();

        myRenderer.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Config.resetToggled)
        {
            myRenderer.enabled = true;
        }
        else
        {
            myRenderer.enabled = false;
        }
    }

    void OnMouseDown()
    {
        if (confirm)
        {
            saveDataScript.deleteSave();
            Config.characterIndex = 0;
            Debug.Log(characterSelector);
            Debug.Log(characterSelectScript);
            characterSelectScript.resetCharacter();
        }
        Config.resetToggled = false;
    }
}
