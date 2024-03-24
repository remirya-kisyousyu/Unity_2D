using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBlockController : MonoBehaviour
{
    private float blockSpeed = 0.01f; //�ړ����x
    private int blockDir = 1; //����

    //�ړ��͈�
    private float upLimit;
    private float downLimit;
    private float moveLength = 4.0f;

    private Transform tr;
    private bool moveFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        tr = gameObject.GetComponent<Transform>();

        //�ړ��͈͂��w��
        upLimit = tr.position.y + moveLength;
        downLimit = tr.position.y - moveLength;
    }

    // Update is called once per frame
    void Update()
    {
        moveFlag ^= true; //update���ɔ��]

        Vector3 vec3 = tr.position;

        if (moveFlag == true)
        {
            //�ړ�
            vec3.y += blockDir * blockSpeed;
            tr.position = vec3;
        }

        //�ړ������̔��]
        if (vec3.y > upLimit) blockDir = -1;
        if (vec3.y < downLimit) blockDir = 1;
    }
}
