using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTotalCoins : MonoBehaviour
{
    private GameObject Settings;
    private SaveData saveDataScript;

    private TextMesh coinTextMesh;
    private Transform myTransform;

    private int totalCoins;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        coinTextMesh = gameObject.GetComponent<TextMesh>();

        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();
        totalCoins = saveDataScript.save.totalCoins;
        coinTextMesh.text = "Total Coins: " + totalCoins;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
