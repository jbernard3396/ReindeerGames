using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayIfMastered : MonoBehaviour
{
    private GameObject Settings;
    private SaveData saveDataScript;

    private int reindeerIndex;
    private int highScore;

    private NumberDisplay numDisplay;

    public bool isMasteredSprite;
    // Start is called before the first frame update
    void Start()
    {
        numDisplay = gameObject.GetComponent<NumberDisplay>();

        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();
    }

    // Update is called once per frame
    void Update()
    {
        reindeerIndex = Config.characterIndex;
        highScore = saveDataScript.save.reindeerCoins[reindeerIndex];
        if (highScore >= 25 && isMasteredSprite)
        {
            numDisplay.enabled = true;
        }
        else if (highScore < 25 && !isMasteredSprite)
        {
            numDisplay.enabled = true;
        }
        else 
        {
            numDisplay.removeNum();
            numDisplay.enabled = false;
        }
    }
}
