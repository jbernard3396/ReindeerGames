using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getCollectedCoins : MonoBehaviour
{
    private GameObject Settings;
    private SaveData saveDataScript;

    private TextMesh coinTextMesh;
    private Transform myTransform;

    private NumberDisplay numDisplay;

    private int collectedCoins;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        coinTextMesh = gameObject.GetComponent<TextMesh>();
        numDisplay = gameObject.GetComponent<NumberDisplay>();

        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();
    }

    // Update is called once per frame
    void Update()
    {
        collectedCoins = saveDataScript.save.collectedCoins;
        numDisplay.displayNum(collectedCoins);
    }
}
