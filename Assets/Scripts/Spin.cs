using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    private Transform myTransform;
    private CircleCollider2D m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        m_Collider = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(m_Collider.bounds.center, Vector3.back, 20 * Time.deltaTime);
    }
}
