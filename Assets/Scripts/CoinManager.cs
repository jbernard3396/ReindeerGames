using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static Config;
using static basicMovement;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject realCoinGold;
    [SerializeField] private GameObject fakeCoinGold;
    [SerializeField] private GameObject realCoinSilver;
    [SerializeField] private GameObject fakeCoinSilver;

    [SerializeField] private GameObject collectedCoinGold;
    [SerializeField] private GameObject collectedCoinSilver;


    private GameObject realCoinInstance;
    private GameObject fakeCoinInstance;
    private GameObject collectedCoinInstance;
    private GameObject ccgo;
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
        Debug.Log(scoreScript.highScore);
        
        CoinCollectSource = GameObject.Find("CoinSFX");
        CoinCollectSFX = CoinCollectSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!realCoinInstance)
        {
            if (scoreScript.highScore == 0)
            {
                ccgo = collectedCoinGold;
                realCoinInstance = Instantiate(realCoinGold, generateLocation(), Quaternion.identity);
                fakeCoinInstance = Instantiate(fakeCoinGold, generateLocation(), Quaternion.identity);
            }
            else
            {
                ccgo = collectedCoinSilver;
                realCoinInstance = Instantiate(realCoinSilver, generateLocation(), Quaternion.identity);
                fakeCoinInstance = Instantiate(fakeCoinSilver, generateLocation(), Quaternion.identity);
            }
            fc_Collider = fakeCoinInstance.GetComponent<CircleCollider2D>();
        }
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
        
        collectedCoinInstance = Instantiate(ccgo, realCoinInstance.transform.position, Quaternion.identity);
        realCoinInstance.transform.position = fc_Collider.bounds.center + new Vector3(0, -.4f, 0);
        fakeCoinInstance.transform.position = generateLocation();
        if (scoreScript.score == scoreScript.highScore - 1)
        {
            ccgo = collectedCoinGold;
            Vector3 rcPos = realCoinInstance.transform.position;
            Vector3 fcPos = fakeCoinInstance.transform.position;
            GameObject.Destroy(realCoinInstance);
            GameObject.Destroy(fakeCoinInstance);
            realCoinInstance = Instantiate(realCoinGold, rcPos, Quaternion.identity);
            fakeCoinInstance = Instantiate(fakeCoinGold, fcPos, Quaternion.identity);
            fc_Collider = fakeCoinInstance.GetComponent<CircleCollider2D>();

        }
        scoreScript.incrementScore(1);
    }
}
