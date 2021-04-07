using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollected : MonoBehaviour
{

    private Transform myBody;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, (spriteRenderer.color.a * .99f * (1-Time.deltaTime)));
        myBody.Translate(Vector3.up * Time.deltaTime * 1f);
        if (spriteRenderer.color.a < .1)
        {
            Destroy(gameObject);
        }
    }
}
