using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;


public class ScoreManager : MonoBehaviour
{
    private GameObject Settings;
    private SaveData saveDataScript;

    private int score = 0;
    private int highScore;

    [SerializeField] private GameObject scoreTextCanvas;
    private GameObject scoreGameObject;
    private TextMesh scoreTextMesh;

    private GameObject highScoreGameObject;
    private TextMesh highScoreTextMesh;

    private int reindeerIndex;
    // Start is called before the first frame update
    void Start()
    {
        scoreGameObject = scoreTextCanvas.transform.Find("scoreText").gameObject;
        scoreTextMesh = scoreGameObject.GetComponent<TextMesh>();

        highScoreGameObject = scoreTextCanvas.transform.Find("highScoreText").gameObject;
        highScoreTextMesh = highScoreGameObject.GetComponent<TextMesh>();


        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();

        reindeerIndex = Config.characterIndex;
        highScore = saveDataScript.save.reindeerCoins[reindeerIndex];
        highScoreTextMesh.text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementScore(int inc = 1)
    {
        score += inc;
        scoreTextMesh.text = "Score: " + score;

        if(highScore < score)
        {
            highScore = score;
            saveDataScript.save.reindeerCoins[reindeerIndex] = score;
            saveDataScript.save.totalCoins += 1;
        }
        highScoreTextMesh.text = "High Score: " + highScore;
    }
}
