using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Config;
using UnityEngine.Analytics;
using UnityEngine.Advertisements;


public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private basicMovement basicMovementScript;

    private GameObject Settings;
    private SaveData saveDataScript;


    [SerializeField] private ScoreManager scoreScript;
    private Ability abilityScript;
    private int reindeerIndex;
    private int highScore;


    // Start is called before the first frame update
    void Start()
    {
        basicMovementScript = player.GetComponent<basicMovement>();



        //All useful only for analytics
        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();

        abilityScript = Config.character;

        reindeerIndex = Config.characterIndex;
        highScore = saveDataScript.save.reindeerCoins[reindeerIndex];
    }

    // Update is called once per frame
    void Update()
    {
        bool restart = Input.GetButtonDown("Fire2");
        if (restart || !basicMovementScript)
        {
            bool allMastered = true;
            for (int i = 0; i < 9; i++) // check for allMastered
            {
                if (saveDataScript.save.reindeerCoins[i] < 25)
                {
                    allMastered = false;
                }
            }
            foreach (Achievement achievement in saveDataScript.save.achievements)
            {
                if (highScore == scoreScript.score && scoreScript.score >= 10)
                {
                    achievement.markAcheived("SoClose");
                }
                if (saveDataScript.save.totalCoins >= 100)
                {
                    achievement.markAcheived("hs_100");
                }
                if (saveDataScript.save.totalCoins >= 250)
                {
                    achievement.markAcheived("hs_250");
                }
                if (saveDataScript.save.totalCoins >= 500)
                {
                    achievement.markAcheived("hs_500");
                }
                if (saveDataScript.save.totalCoins >= 200)
                {
                    Debug.Log("all unlocked");
                    achievement.markAcheived("unlockAll");
                }
                if (allMastered)
                {
                    Debug.Log("all mastered");
                    achievement.markAcheived("masterAll");
                }

            }
            saveDataScript.saveGame();
            Debug.Log("saving game");
            Config.score = scoreScript.score;
            Time.timeScale = 1f;
            SceneManager.LoadScene("GameOver");

            Debug.Log(AnalyticsEvent.Custom(abilityScript.getName() + " score", new Dictionary<string, object>
            {
                {"Score", scoreScript.score }
            }));
        }
    }
}
