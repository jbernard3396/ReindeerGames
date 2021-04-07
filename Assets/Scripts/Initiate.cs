using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Initiate : MonoBehaviour
{
    public GameObject SaveObject;

    private void Start()
    {
        Instantiate(SaveObject);
        SceneManager.LoadScene("Menu");

    }
}
