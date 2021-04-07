using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;

public class NumberDisplay : MonoBehaviour
{
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;
    public Sprite zero;

    public float xOffset;
    public float yOffset;
    public float scaleOffset;
    private float scale;

    private float charWidth = -1;
    private int numChars = 0;

    private Transform myTransform;

    private Sprite[] spriteArray = new Sprite[10];
    private GameObject[] goArray = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {

        myTransform = gameObject.GetComponent<Transform>();
        scale = 1;//Config.getCrx() / Config.getCty();
        scale = scale * scaleOffset;

        spriteArray[0] = zero;
        spriteArray[1] = one;
        spriteArray[2] = two;
        spriteArray[3] = three;
        spriteArray[4] = four;
        spriteArray[5] = five;
        spriteArray[6] = six;
        spriteArray[7] = seven;
        spriteArray[8] = eight;
        spriteArray[9] = nine;

    }

    public void removeNum()
    {
        foreach (GameObject go in goArray)
        {
            GameObject.Destroy(go);
        }
    }

    public void displayNum(int num)
    {
        if (!this.enabled)
        {
            return;
        }
        removeNum();
        numChars = 0;
        string stnum = num.ToString();
        
        foreach (char digit in stnum)
        {
            string stdigit = digit.ToString();
            int newDig  = int.Parse(stdigit);
            GameObject go = new GameObject("New Sprite");
            Transform got = go.GetComponent<Transform>();
            got.localScale  = new Vector3(scale, scale, scale);



            SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
            renderer.sprite = spriteArray[newDig];
            if (charWidth == -1)
            {
                charWidth = renderer.bounds.size.x;
            }


            got.position = new Vector3(myTransform.position.x + (charWidth * numChars) + xOffset, myTransform.position.y + yOffset, myTransform.position.z);

            goArray[numChars] = go;
            numChars += 1;
        }
    }
}
