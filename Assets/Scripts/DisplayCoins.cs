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
        myTextMesh = gameObject.GetComponent<TextMesh>();

        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();

        reindeerIndex = Config.characterIndex;
        highScore = saveDataScript.save.reindeerCoins[reindeerIndex];

        characterCosts = Config.characterCosts;

        masteredColor = new Color(100, 100, 0, 255);
        originalColor = myTextMesh.color;

    }

    // Update is called once per frame
    void Update()
    {
        reindeerIndex = Config.characterIndex;
        if (!Config.CharacterLocked)
        {
            highScore = saveDataScript.save.reindeerCoins[reindeerIndex];
            myTextMesh.text = "HighScore: " + highScore;
            if (highScore >= 25)
            {
                myTextMesh.color = masteredColor;
            } else
            {
                myTextMesh.color = originalColor;
            }
        } else
        {
            cost = characterCosts[reindeerIndex];
            myTextMesh.text = "Cost: " + cost;
        }
    }
}
