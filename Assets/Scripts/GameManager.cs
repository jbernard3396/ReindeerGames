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
        if (restart || !basicMovementScript)// && basicMovementScript.dead)
        {
            Config.score = scoreScript.score;
            SceneManager.LoadScene("GameOver");

            Debug.Log(AnalyticsEvent.Custom(abilityScript.getName() + " score", new Dictionary<string, object>
            {
                {"Score", scoreScript.score }
            }));
        }
    }
}
