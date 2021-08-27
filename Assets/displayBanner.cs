using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;

public class displayBanner : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform myTransform;
    private SpriteRenderer myRenderer;
    private GameObject secondGameObject;
    private Transform secondTransform;
    private SpriteRenderer secondRenderer;
    //private GameObject bgGameObject;
    //private Transform bgTransform;
    //private SpriteRenderer bgRenderer;
    //public Sprite bgSprite;
    private bool displaying = false;
    private bool goingDown = false;
    private bool goingUp = false;
    private float stillTime = 1.5f;
    private float stillTimer = 0;
    private float targetY;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {

        myTransform = gameObject.GetComponent<Transform>();
        myTransform.position = new Vector3(myTransform.position.x, Config.getCty()+1, myTransform.position.z);
        targetY = Config.getCty();
        secondGameObject = new GameObject();
        secondRenderer = secondGameObject.AddComponent<SpriteRenderer>();
        if (!secondGameObject.GetComponent<Transform>())
        {
            secondTransform = secondGameObject.AddComponent<Transform>();
        }
        DontDestroyOnLoad(secondGameObject);
        //bgGameObject = new GameObject();
        //bgRenderer = bgGameObject.AddComponent<SpriteRenderer>();
        //bgTransform = bgGameObject.AddComponent<Transform>();
        //DontDestroyOnLoad(bgGameObject);

    }

    public void display(Sprite achievementSprite, Sprite acheivementDescription)
    {
        stillTimer = 0;
        Debug.Log("sprite rendering " + achievementSprite);
        Debug.Log("sprite rendering " + acheivementDescription);

        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (myRenderer == null)
        {
            myRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        myTransform = gameObject.GetComponent<Transform>();
        if (myRenderer == null)
        {
            myTransform = gameObject.AddComponent<Transform>();
        }
        if (secondGameObject == null)
        {
            secondGameObject = new GameObject();
        }
        if (secondRenderer == null)
        {
            secondRenderer = secondGameObject.AddComponent<SpriteRenderer>();
        }
        secondTransform = secondGameObject.GetComponent<Transform>();
        if (secondTransform == null)
        {
            secondTransform = secondGameObject.AddComponent<Transform>();
        }
        //if (bgGameObject == null)
        //{
        //    bgGameObject = new GameObject();
        //}
        //if (secondRenderer == null)
        //{
        //    bgRenderer = bgGameObject.AddComponent<SpriteRenderer>();
        //}
        //bgTransform = bgGameObject.GetComponent<Transform>();
        //if (secondTransform == null)
        //{
        //    bgTransform = bgGameObject.AddComponent<Transform>();
        //}
        myRenderer.enabled = true;
        secondRenderer.enabled = true;
        //bgRenderer.enabled = true;
        myTransform.position = new Vector3(myTransform.position.x, Config.getCty() + 1, myTransform.position.z);
        secondTransform.position = new Vector3(myTransform.position.x+8.5f, Config.getCty() + 1, myTransform.position.z+1);
        //bgTransform.position = new Vector3(myTransform.position.x + 8, Config.getCty() + 1, myTransform.position.z + 2);
        displaying = true;
        goingDown = true;
        myRenderer.sprite = achievementSprite;
        secondRenderer.sprite = acheivementDescription;
        //bgRenderer.sprite = bgSprite;

        Debug.Log("instantiate " + acheivementDescription);
        //Instantiate(acheivementSprite);
        //Instantiate(acheivementDescription);
    }

    // Update is called once per frame
    void Update()
    {
        if (goingDown && displaying)
        {
            myTransform.position = new Vector3(myTransform.position.x, myTransform.position.y - 2 * Time.deltaTime, myTransform.position.z);
            secondTransform.position = new Vector3(secondTransform.position.x, secondTransform.position.y - 2 * Time.deltaTime, secondTransform.position.z);
            if (myTransform.position.y <= targetY)
            {
                goingDown = false;
            }
            //bgTransform.position = new Vector3(secondTransform.position.x-1, secondTransform.position.y, bgTransform.position.z);
        }
        if (!goingDown && !goingUp && displaying)
        {
            stillTimer += Time.deltaTime;
            if(stillTimer >= stillTime)
            {
                goingUp = true;
            }
            //bgTransform.position = new Vector3(secondTransform.position.x-1, secondTransform.position.y, bgTransform.position.z);
        }
        if(goingUp && displaying)
        {
            myTransform.position = new Vector3(myTransform.position.x, myTransform.position.y + 2 * Time.deltaTime, myTransform.position.z);
            secondTransform.position = new Vector3(secondTransform.position.x, secondTransform.position.y + 2 * Time.deltaTime, secondTransform.position.z);
            if (myTransform.position.y >= Config.getCty()+1)
            {
                myRenderer.enabled = false;
                secondRenderer.enabled = false;
                //bgRenderer.enabled = false;
                goingUp = false;
                displaying = false;
            }
            //bgTransform.position = new Vector3(secondTransform.position.x-1, secondTransform.position.y, bgTransform.position.z);
        }
        
    }
}

