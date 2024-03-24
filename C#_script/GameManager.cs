using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //ゲームクリア、ゲームオーバー画像
    public Sprite gameClearImage;
    public Sprite gameOverImage;

    public GameObject mainImage;

    // Start is called before the first frame update
    void Start()
    {
        //ゲームスタート画像を1秒間表示
        Invoke("InActiveImage", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ゲームスタート画像を非表示にする
    private void InActiveImage()
    {
        mainImage.SetActive(false);
    }

    //スタート画面に戻る
    private void CallTitle()
    {
        SceneManager.LoadScene("StartScene");
    }

    //ゲームクリア
    public void GameClear()
    {
        //ゲームクリアの表示
        mainImage.GetComponent<Image>().sprite = gameClearImage;
        mainImage.SetActive(true);

        //スタート画面に戻る
        Invoke("CallTitle", 2.0f);
    }

    //ゲームオーバー
    public void GameOver()
    {
        //ゲームオーバーの表示
        mainImage.GetComponent<Image>().sprite = gameOverImage;
        mainImage.SetActive(true);

        //スタート画面に戻る
        Invoke("CallTitle", 2.0f);
    }
}
