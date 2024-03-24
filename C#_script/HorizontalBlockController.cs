using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBlockController : MonoBehaviour
{
    private float blockSpeed = 0.01f; //移動速度
    private int blockDir = 1; //向き

    //移動制限
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
        moveFlag ^= true; //update毎に反転

        Vector3 vec3 = tr.position;

        if (moveFlag == true)
        {
            //移動
            vec3.x += blockDir * blockSpeed;
            tr.position = vec3;
        }

        //移動向きの反転
        if (vec3.x > rightLimit) blockDir = -1;
        if (vec3.x < leftLimit) blockDir = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //プレイヤーが一緒に移動できるようにする
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //同期を解除
            collision.transform.SetParent(null);
        }
    }
}
