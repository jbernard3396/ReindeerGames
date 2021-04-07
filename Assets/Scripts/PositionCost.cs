using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;


public class PositionCost : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 ogPosition;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        ogPosition = myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Config.CharacterLocked)
        {
            myTransform.position = new Vector3(ogPosition.x - .75f, ogPosition.y, ogPosition.z);
        } else
        {
            myTransform.position = ogPosition;
        }
    }
}
