using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player; //プレイヤー情報格納用
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの情報を取得
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //プレイヤーに追従
        if(playerController.gamePlayingFlag == true)
        {
            transform.position = new Vector3(player.transform.position.x,
                player.transform.position.y, transform.position.z);
        }
        
    }
}
