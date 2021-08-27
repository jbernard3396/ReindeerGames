using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSelector : MonoBehaviour
{
    public Sprite description;
    private GameObject pointer;
    private GameObject canvas;

    private GameObject testObject;

    private GameObject Descriptor;
    private AchievementDescriptor descriptorScript;
    //private GameObject cameraObject;
    //private Camera camera;

    void Start()
    {


        Descriptor = GameObject.Find("AchievementDescription");
        descriptorScript = Descriptor.GetComponent<AchievementDescriptor>();
        canvas = GameObject.Find("Canvas");
        //cameraObject = GameObject.Find("Main Camera");
        //camera = cameraObject.GetComponent<Camera>();
    }

    void OnMouseDown()
    {
        descriptorScript.achievementSelected = description;
        //testObject = new GameObject();
        //testObject.AddComponent<SpriteRenderer>();
        //testObject.GetComponent<SpriteRenderer>().sprite = description;
    }

    void Update()
    {
        //if(testObject != null)
        //{
        //    Vector3 mousePos = Input.mousePosition;
        //    {
        //        var screenPoint = Input.mousePosition;
        //        screenPoint.z = 10.0f; //distance of the plane from the camera
        //        testObject.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        //        testObject.transform.position = new Vector3(testObject.transform.position.x + 5, testObject.transform.position.y -.7f, testObject.transform.position.z);
        //    }
        //}
    }

    //void OnMouseUp()
    //{
    //    Destroy(testObject);
    //}
}
