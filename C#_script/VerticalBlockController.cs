using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBlockController : MonoBehaviour
{
    private float blockSpeed = 0.01f; //Ú®¬x
    private int blockDir = 1; //ü«

    //Ú®ÍÍ
    private float upLimit;
    private float downLimit;
    private float moveLength = 4.0f;

    private Transform tr;
    private bool moveFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        tr = gameObject.GetComponent<Transform>();

        //Ú®ÍÍðwè
        upLimit = tr.position.y + moveLength;
        downLimit = tr.position.y - moveLength;
    }

    // Update is called once per frame
    void Update()
    {
        moveFlag ^= true; //updateÉ½]

        Vector3 vec3 = tr.position;

        if (moveFlag == true)
        {
            //Ú®
            vec3.y += blockDir * blockSpeed;
            tr.position = vec3;
        }

        //Ú®ü«Ì½]
        if (vec3.y > upLimit) blockDir = -1;
        if (vec3.y < downLimit) blockDir = 1;
    }
}
