using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReplay : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform myBody;

    void Start()
    {
        myBody = GetComponent<Transform>();
        if (Config.restartAdUsed)
        {
            myBody.position = new Vector3(0, myBody.position.y, myBody.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
