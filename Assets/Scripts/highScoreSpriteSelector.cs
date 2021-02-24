using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;

public class highScoreSpriteSelector : MonoBehaviour
{
    private SpriteRenderer myRenderer;

    private GameObject Settings;
    private SaveData saveDataScript;
    private Transform myTransform;

    private int reindeerIndex;
    private int highScore;
    private int cost;

    private Vector3 ogPosition;


    private int[] characterCosts = new int[9];


    public Sprite normalSprite;
    public Sprite masteredSprite;
    public Sprite costSprite;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        ogPosition = myTransform.position;

        characterCosts = Config.characterCosts;


        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();

        reindeerIndex = Config.characterIndex;
        highScore = saveDataScript.save.reindeerCoins[reindeerIndex];

        myRenderer.sprite = normalSprite;
        if (highScore >= 25)
        {
            myRenderer.sprite = masteredSprite;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        myTransform.position = ogPosition;
        reindeerIndex = Config.characterIndex;
        highScore = saveDataScript.save.reindeerCoins[reindeerIndex];
        myRenderer.sprite = normalSprite;
        if (highScore >= 25)
        {
            myRenderer.sprite = masteredSprite;
        } 
        if (Config.CharacterLocked)
        {
            myTransform.position = new Vector3(ogPosition.x -1, ogPosition.y, ogPosition.z);
            myRenderer.sprite = costSprite;
        }
    }
}
