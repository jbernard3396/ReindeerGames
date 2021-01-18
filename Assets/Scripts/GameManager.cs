using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private basicMovement basicMovementScript;
    

    // Start is called before the first frame update
    void Start()
    {
        basicMovementScript = player.GetComponent<basicMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        bool restart = Input.GetButtonDown("Fire2");
        if (restart || !basicMovementScript)// && basicMovementScript.dead)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
