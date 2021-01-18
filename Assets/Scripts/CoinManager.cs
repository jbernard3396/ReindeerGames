using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static Config;
using static basicMovement;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject realCoin;
    [SerializeField] private GameObject fakeCoin;
    [SerializeField] private GameObject collectedCoin;

    private GameObject realCoinInstance;
    private GameObject fakeCoinInstance;
    private GameObject collectedCoinInstance;


    private float leftBound = Config.getClx() + 3;
    private float rightBound = Config.getCrx() - 3;
    private float bottomBound = Config.getCby();
    private float topBound = Config.getCty()*.6f;

    [SerializeField] private ScoreManager scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        realCoinInstance = Instantiate(realCoin, generateLocation(), Quaternion.identity);
        fakeCoinInstance = Instantiate(fakeCoin, generateLocation(), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(new Vector3(rightBound, bottomBound, 0), Vector3.up*10, Color.yellow);
        //Debug.DrawRay(new Vector3(leftBound, bottomBound, 0), Vector3.up*10, Color.yellow);
    }

    private Vector3 generateLocation()
    {
        float x = UnityEngine.Random.Range(rightBound, leftBound);
        float y = UnityEngine.Random.Range(bottomBound, topBound);
        float z = 0;
        return new Vector3(x, y, z);
    }

    public void collectCoin()
    {
        collectedCoinInstance = Instantiate(collectedCoin, realCoinInstance.transform.position, Quaternion.identity);
        realCoinInstance.transform.position = fakeCoinInstance.transform.position;
        fakeCoinInstance.transform.position = generateLocation();
        scoreScript.incrementScore(1);
    }
}
