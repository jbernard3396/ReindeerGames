using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;


public class DisplayCoins : MonoBehaviour
{
    private TextMesh myTextMesh;

    private GameObject Settings;
    private SaveData saveDataScript;
    private Transform myTransform;
    private Vector3 ogPosition;
    private NumberDisplay numDisplay;


    private int reindeerIndex;
    private int highScore;
    private int cost;

    private Color masteredColor;
    private Color originalColor;

    private int[] characterCosts = new int[9];

    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        ogPosition = myTransform.position;
        numDisplay = gameObject.GetComponent<NumberDisplay>();


        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();

        reindeerIndex = Config.characterIndex;
        highScore = saveDataScript.save.reindeerCoins[reindeerIndex];

        characterCosts = Config.characterCosts;

        masteredColor = new Color(.94f, .76f, .24f, 1);

    }

    // Update is called once per frame
    void Update()
    {
        reindeerIndex = Config.characterIndex;
        if (!Config.CharacterLocked)
        {
            numDisplay.xOffset = 0;
            myTransform.position = ogPosition;
            highScore = saveDataScript.save.reindeerCoins[reindeerIndex];
            numDisplay.displayNum(highScore);
        } else
        {
            //myTransform.position = new Vector3(-2, ogPosition.y, ogPosition.z);
            cost = characterCosts[reindeerIndex];
            numDisplay.xOffset = -1;
            numDisplay.displayNum(cost);
        }
    }
}
