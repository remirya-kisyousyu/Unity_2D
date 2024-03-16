using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCotroller : MonoBehaviour
{
    private float batSpeed = 0.01f;
    private float SearchRange = 5.0f;
    private float currDistance = 0;

    //�ړ���
    private float batMoveX = 0;
    private float batMoveY = 0;

    //����
    private float currDistanceX = 0;
    private float currDistanceY = 0;

    private bool batFlying = false; //�A�j���[�V�����Ǘ�

    //�A�j���[�^�[
    Animator animator;
    public string hangAnime = "Bat-Hang-Animation";
    public string flyingAnime = "bat-Fly-Animation";

    private Transform playerTransform; //�v���C���[
    private Transform batTransform; //bat

    // Start is called before the first frame update
    void Start()
    {
        //bat�̈ʒu���擾
        batTransform = GetComponent<Transform>();

        //bat�̃A�j���[�^�[�̎擾
        animator = GetComponent<Animator>();

        //�v���C���[�̈ʒu���擾
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[��bat�̋���
        currDistanceX = playerTransform.position.x - batTransform.position.x;
        currDistanceY = playerTransform.position.y - batTransform.position.y;
        currDistance = Math.Abs(currDistanceX) + Math.Abs(currDistanceY);

        //�ҋ@��Ԃ̏ꍇ
        if (batFlying == false)
        {
            animator.Play(hangAnime);

            if(currDistance < SearchRange)
            {
                batFlying = true;
            }
        }

        //���ł���ꍇ
        else if(batFlying == true)
        {
            animator.Play(flyingAnime);

            batMoveX = currDistanceX / currDistance;
            batMoveY = currDistanceY / currDistance;

            Vector3 vec3 = new Vector3(batSpeed * batMoveX / 2, batSpeed * batMoveY / 2, 0);
            batTransform.position += vec3;
        }
    }
}
