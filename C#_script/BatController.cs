using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    private float batSpeed = 0.01f;
    private float SearchRange = 4.0f;
    private float currDistance = 0;

    //移動量
    private float batMoveX = 0;
    private float batMoveY = 0;

    //距離
    private float currDistanceX = 0;
    private float currDistanceY = 0;

    private bool batFlying = false; //アニメーション管理

    //アニメーター
    private Animator animator;

    public string hangAnime = "Bat-Hang-Animation";
    public string flyingAnime = "bat-Fly-Animation";

    private Transform playerTransform; //プレイヤー
    private PlayerController playerScript;

    private Transform batTransform; //bat

    // Start is called before the first frame update
    void Start()
    {
        batTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーとbatの距離
        currDistanceX = playerTransform.position.x - batTransform.position.x;
        currDistanceY = playerTransform.position.y - batTransform.position.y;
        currDistance = Math.Abs(currDistanceX) + Math.Abs(currDistanceY);

        //待機状態の場合
        if (batFlying == false)
        {
            animator.Play(hangAnime);

            if(currDistance < SearchRange)
            {
                batFlying = true;
            }
        }

        //飛んでいる場合
        else if(batFlying == true)
        {
            //ゲーム状態の確認
            if(playerScript.gamePlayingFlag != true)
            {
                return; //追跡停止
            }

            animator.Play(flyingAnime);

            batMoveX = currDistanceX / currDistance;
            batMoveY = currDistanceY / currDistance;

            Vector3 vec3 = new Vector3(batSpeed * batMoveX / 2, batSpeed * batMoveY / 2, 0);
            batTransform.position += vec3;
        }
    }
}
