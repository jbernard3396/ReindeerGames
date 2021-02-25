using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Transform myTransform;
    private Transform targetTransform;

    public GameObject target;
    public float yOffset;
    public float xOffset;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            targetTransform = target.GetComponent<Transform>();
            myTransform.position = new Vector3(targetTransform.position.x + xOffset, targetTransform.position.y + yOffset, targetTransform.position.z);
        }
    }
}
