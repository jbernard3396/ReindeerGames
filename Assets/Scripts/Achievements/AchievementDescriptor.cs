using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementDescriptor : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite achievementSelected;
    public Sprite achievementDefault;
    public Sprite achievementHighlighter;
    private SpriteRenderer mySpriteRenderer;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (achievementSelected == null)
        {
            mySpriteRenderer.sprite = achievementDefault;
        } else
        {
            mySpriteRenderer.sprite = achievementSelected;
        }
        
    }
}
