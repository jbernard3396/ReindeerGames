using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;

public class characterSelect : MonoBehaviour
{
    private GameObject Settings;
    private SaveData saveDataScript;

    private Transform myTransform;
    private Animator anim;

    private int highScore;


    [SerializeField] private Ability dasherScript;
    [SerializeField] private Ability dancerScript;
    [SerializeField] private Ability prancerScript;
    [SerializeField] private Ability vixenScript;
    [SerializeField] private Ability cometScript;
    [SerializeField] private Ability cupidScript;
    [SerializeField] private Ability donnerScript;
    [SerializeField] private Ability blitzenScript;
    [SerializeField] private Ability rudolphScript;

    private Ability[] scripts = new Ability[9];
    private int[] characterCosts = new int[9];

    private int scriptIndex;

    private Ability currentScript;
    private string currentName;

    // Start is called before the first frame update
    void Start()
    {
        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();

        myTransform = gameObject.GetComponent<Transform>();
        anim = GetComponent<Animator>();


        scripts[0]=(dasherScript);
        scripts[1]=(dancerScript);
        scripts[2]=(prancerScript);
        scripts[3]=(vixenScript);
        scripts[4]=(cometScript);
        scripts[5]=(cupidScript);
        scripts[6]=(donnerScript);
        scripts[7]=(blitzenScript);
        scripts[8]=(rudolphScript);

        characterCosts[0] = 0; //dasher
        characterCosts[1] = 10; //dancer
        characterCosts[2] = 20; //Prancer
        characterCosts[3] = 40; //Vixen
        characterCosts[4] = 75; //Comet
        characterCosts[5] = 100; //Cupid
        characterCosts[6] = 120; //Donner
        characterCosts[7] = 150; //Blitzen
        characterCosts[8] = 200; //Rudolph

        Config.characterCosts = characterCosts;

        scriptIndex = Config.characterIndex;
        anim.SetInteger("Character", scriptIndex);
        setCharacter();
    }

    public void incrementCharacter(bool forward = true)
    {
        scriptIndex += forward ? 1 : -1;
        
        if (scriptIndex < 0)
        {
            scriptIndex = 8;
        }
        scriptIndex = scriptIndex % 9;
        setCharacter();
    }

    void setCharacter()
    {
        currentScript = scripts[scriptIndex];
        currentName = currentScript.getName();

        Config.character = currentScript;
        Config.characterIndex = scriptIndex;
        anim.SetInteger("Character", scriptIndex);

        highScore = saveDataScript.save.reindeerCoins[scriptIndex];

        if (characterCosts[scriptIndex] <= saveDataScript.save.totalCoins || (Config.allUnlocked == true))
        {
            Config.characterLocked = false;
            anim.SetBool("Locked", false);
        }

        if (characterCosts[scriptIndex] > saveDataScript.save.totalCoins && (Config.allUnlocked == false))
        {
            Config.characterLocked = true;
            anim.SetBool("Locked", true);
        }

        if(highScore >= 25)
        {
            anim.SetBool("Mastered", true);
        } else
        {
            anim.SetBool("Mastered", false);
        }
    }
}
