using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightAchievement : MonoBehaviour
{
    private GameObject Settings;
    private SaveData saveDataScript;

    public string myKey;
    private bool unlocked = false;
    private Achievement myAchievement;

    private SpriteRenderer mySpriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        Settings = GameObject.FindWithTag("Settings");
        saveDataScript = Settings.GetComponent<SaveData>();
        myAchievement = saveDataScript.save.achievements.Find(x => x.title == myKey);

        if (myAchievement != null)
        {
            //Debug.Log("succesfully loaded: " + myKey);
            unlocked = myAchievement.isUnlocked();
        }
        else
        {
            Debug.Log("Failed to load: " + myKey);
        }


        if (unlocked)
        {
            mySpriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }

}
