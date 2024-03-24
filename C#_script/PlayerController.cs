using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool jumpFlag = false; //�W�����v���t���O
    public bool gamePlayingFlag = true; //�Q�[�����t���O

    private float playerSpeed = 6.0f; //�ړ����x
    private float playerJump = 30.0f; //�W�����v�̍���
    private string playerDir = "right"; //�E����

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Transform tr;

    //�A�j���[�^�[
    private Animator animator;

    public string stopAnime = "Idle-Animation";
    public string runAnime = "run-Animation";

    //GameManager�̊֐����g��
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
        //�Q�[����
        if(gamePlayingFlag == true)
        {
            //���E�̃L�[���͂��擾
            float keyX = Input.GetAxis("Horizontal");

            //�A�j���[�V�����ω�
            if (keyX != 0 && jumpFlag == false) animator.Play(runAnime);
            else animator.Play(stopAnime);

            //�L�[���͂ɉ����ăv���C���[���ړ�
            rb.velocity = new Vector2(keyX * playerSpeed, rb.velocity.y);

            //�v���C���[�̌����𔽓]
            FlipPlayer(keyX);

            //�X�y�[�X�̃L�[���͂��擾
            bool keySpace = Input.GetKey(KeyCode.Space);

            if (keySpace == true && jumpFlag == false)
            {
                jumpFlag = true; //��i�W�����v���󂯕t���Ȃ�

                //�W�����v����
                rb.AddForce(tr.up * playerJump, ForceMode2D.Impulse);
            }
        }
    }

    //�v���C���[�̌����𔽓]
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

    //�v���C���[�ƒn�ʂ��ڐG���Ă��邩
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //�W�����v���\�ɂ���
            jumpFlag = false;
        }

        else if (collision.gameObject.CompareTag("MoveBlock"))
        {
            jumpFlag = false;
        }
    }

    //�g���K�[�ƐڐG������
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //�S�[���ƐڐG
        if (collider.gameObject.CompareTag("Goal"))
        {
            //�Q�[�����~
            GameStop();

            GameClear();
        }

        //�G�ƐڐG
        if (collider.gameObject.CompareTag("Enemy"))
        {
            //�Q�[�����~
            GameStop();

            GameOver();
        }
    }

    //�Q�[���̒�~
    private void GameStop()
    {
        //�L�[���͂̒�~
        gamePlayingFlag = false;

        //�v���C���[���~
        rb.velocity = new Vector2(0, 0);

        //�ҋ@�A�j���[�V�������w��
        animator.Play((stopAnime));
    }

    //�Q�[���N���A
    private void GameClear()
    {
        //�L�[���͂̒�~
        gamePlayingFlag = false;

        //�Q�[���N���A�֐����Ăяo��
        gameManager.GameClear();
    }

    //�Q�[���I�[�o�[
    private void GameOver()
    {
        //�L�[���͂̒�~
        gamePlayingFlag = false;

        //�Q�[���I�[�o�[�֐����Ăяo��
        gameManager.GameOver();
    }
}