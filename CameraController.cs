using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player; //�v���C���[���i�[�p

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̏����擾
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //�v���C���[�ɒǏ]
        transform.position =new Vector3( player.transform.position.x, transform.position.y, transform.position.z);
    }
}
