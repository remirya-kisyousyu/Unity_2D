using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool jumpFlag = false; //ジャンプ中フラグ
    public bool gamePlayingFlag = true; //ゲーム中フラグ

    private float playerSpeed = 6.0f; //移動速度
    private float playerJump = 30.0f; //ジャンプの高さ
    private string playerDir = "right"; //右向き

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Transform tr;

    //アニメーター
    private Animator animator;

    public string stopAnime = "Idle-Animation";
    public string runAnime = "run-Animation";

    //GameManagerの関数を使う
    public GameObject canvas;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        gameManager = canvas.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //ゲーム中
        if(gamePlayingFlag == true)
        {
            //左右のキー入力を取得
            float keyX = Input.GetAxis("Horizontal");

            //アニメーション変化
            if (keyX != 0 && jumpFlag == false) animator.Play(runAnime);
            else animator.Play(stopAnime);

            //キー入力に応じてプレイヤーを移動
            rb.velocity = new Vector2(keyX * playerSpeed, rb.velocity.y);

            //プレイヤーの向きを反転
            FlipPlayer(keyX);

            //スペースのキー入力を取得
            bool keySpace = Input.GetKey(KeyCode.Space);

            if (keySpace == true && jumpFlag == false)
            {
                jumpFlag = true; //二段ジャンプを受け付けない

                //ジャンプ処理
                rb.AddForce(tr.up * playerJump, ForceMode2D.Impulse);
            }
        }
    }

    //プレイヤーの向きを反転
    private void FlipPlayer(float keyX)
    {
        if (keyX > 0 && playerDir != "right")
        {
            sr.flipX = false;
            playerDir = "right";
        }
        else if (keyX < 0 && playerDir != "left")
        {
            sr.flipX = true;
            playerDir = "left";
        }
        else return;
    }

    //プレイヤーと地面が接触しているか
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //ジャンプを可能にする
            jumpFlag = false;
        }

        else if (collision.gameObject.CompareTag("MoveBlock"))
        {
            jumpFlag = false;
        }
    }

    //トリガーと接触したか
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //ゴールと接触
        if (collider.gameObject.CompareTag("Goal"))
        {
            //ゲームを停止
            GameStop();

            GameClear();
        }

        //敵と接触
        if (collider.gameObject.CompareTag("Enemy"))
        {
            //ゲームを停止
            GameStop();

            GameOver();
        }
    }

    //ゲームの停止
    private void GameStop()
    {
        //キー入力の停止
        gamePlayingFlag = false;

        //プレイヤーを停止
        rb.velocity = new Vector2(0, 0);

        //待機アニメーションを指定
        animator.Play((stopAnime));
    }

    //ゲームクリア
    private void GameClear()
    {
        //キー入力の停止
        gamePlayingFlag = false;

        //ゲームクリア関数を呼び出す
        gameManager.GameClear();
    }

    //ゲームオーバー
    private void GameOver()
    {
        //キー入力の停止
        gamePlayingFlag = false;

        //ゲームオーバー関数を呼び出す
        gameManager.GameOver();
    }
}