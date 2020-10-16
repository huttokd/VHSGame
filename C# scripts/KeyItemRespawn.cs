using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemRespawn : MonoBehaviour
{
    Vector3 startPos;
    public float yMin = -10f;


    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yMin)
        {
            transform.position = startPos;
        }


    }
}
