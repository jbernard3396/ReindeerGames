using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayHighScoreInGame : MonoBehaviour
{

    private NumberDisplay numDisplay;
    private TextMesh myTextMesh;



    // Start is called before the first frame update
    void Start()
    {
        myTextMesh = gameObject.GetComponent<TextMesh>();
        numDisplay = gameObject.GetComponent<NumberDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        int num = int.Parse(myTextMesh.text);
        numDisplay.displayNum(num);
    }
}
