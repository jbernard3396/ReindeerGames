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
    private CircleCollider2D fc_Collider;
    private GameObject CoinCollectSource;
    private AudioSource CoinCollectSFX;


    private float leftBound;
    private float rightBound;
    private float bottomBound;
    private float topBound;

    [SerializeField] private ScoreManager scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        leftBound = Config.getClx() + 3;
        rightBound = Config.getCrx() - 3;
        bottomBound = Config.getCby()+.1f;
        topBound = Config.getCty() *.6f;
        realCoinInstance = Instantiate(realCoin, generateLocation(), Quaternion.identity);
        fakeCoinInstance = Instantiate(fakeCoin, generateLocation(), Quaternion.identity);
        fc_Collider = fakeCoinInstance.GetComponent<CircleCollider2D>();
        CoinCollectSource = GameObject.Find("CoinSFX");
        CoinCollectSFX = CoinCollectSource.GetComponent<AudioSource>();
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
        CoinCollectSFX.Play();
        collectedCoinInstance = Instantiate(collectedCoin, realCoinInstance.transform.position, Quaternion.identity);
        realCoinInstance.transform.position = fc_Collider.bounds.center + new Vector3(0, -.4f, 0);
        fakeCoinInstance.transform.position = generateLocation();
        scoreScript.incrementScore(1);
    }
}
