using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;
using UnityEngine.Analytics;


public class ScoreManager : MonoBehaviour
{
    private GameObject Settings;
    private SaveData saveDataScript;
    private NumberDisplay numDisplay;


    public int score = 0;
    public int highScore;

    [SerializeField] private GameObject scoreTextCanvas;
    private GameObject scoreGameObject;
    private TextMesh scoreTextMesh;

    private GameObject highScoreGameObject;
    private TextMesh highScoreTextMesh;

    private int reindeerIndex;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting scores");
        scoreGameObject = scoreTextCanvas.transform.Find("scoreText").gameObject;
        numDisplay = gameObject.GetComponent<NumberDisplay>();


        highScoreGameObject = scoreTextCanvas.transform.Find("highScoreText").gameObject;
        highScoreTextMesh = highScoreGameObject.GetComponent<TextMesh>();


        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();

        reindeerIndex = Config.characterIndex;

        score = Config.score;




        highScore = saveDataScript.save.reindeerCoins[reindeerIndex];
        highScoreTextMesh.text = "" + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        numDisplay.displayNum(score);

    }

    public void incrementScore(int inc = 1)
    {
        score += inc;
        //scoreTextMesh.text = "" + score;
        //numDisplay.displayNum(score);
        Ability abilityScript = Config.character;
        string name = abilityScript.getName();

        if (highScore < score)
        {
            highScore = score;
            saveDataScript.save.reindeerCoins[reindeerIndex] = score;
            saveDataScript.save.totalCoins += 1;
            Debug.Log(highScore);
            if (highScore == 25)
            {
                Debug.Log(AnalyticsEvent.Custom("Mastered " + name, new Dictionary<string, object>
                    {
                        { "timeUntilMaster",  System.DateTime.Now.Subtract(saveDataScript.save.startDate) }
                    }));
            }

            for (int i = 0; i<9; i++) // check for new unlocks
            {
                if (Config.characterCosts[i] == saveDataScript.save.totalCoins)
                {
                    Debug.Log(AnalyticsEvent.Custom("Unlocked " + i, new Dictionary<string, object>
                    {
                        { "timeUntilUnlock",  System.DateTime.Now.Subtract(saveDataScript.save.startDate) }
                    }));
                }
            };
        }
        highScoreTextMesh.text = "" + highScore;
    }
}
