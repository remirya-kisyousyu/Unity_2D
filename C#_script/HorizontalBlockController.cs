using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBlockController : MonoBehaviour
{
    private float blockSpeed = 0.01f; //�ړ����x
    private int blockDir = 1; //����

    //�ړ�����
    private float leftLimit;
    private float rightLimit;
    private float moveLength = 3.6f;

    private Transform tr;
    private bool moveFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        tr = gameObject.GetComponent<Transform>();
        leftLimit = tr.position.x - moveLength;
        rightLimit = tr.position.x + moveLength;
    }

    // Update is called once per frame
    void Update()
    {
        moveFlag ^= true; //update���ɔ��]

        Vector3 vec3 = tr.position;

        if (moveFlag == true)
        {
            //�ړ�
            vec3.x += blockDir * blockSpeed;
            tr.position = vec3;
        }

        //�ړ������̔��]
        if (vec3.x > rightLimit) blockDir = -1;
        if (vec3.x < leftLimit) blockDir = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //�v���C���[���ꏏ�Ɉړ��ł���悤�ɂ���
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //����������
            collision.transform.SetParent(null);
        }
    }
}
