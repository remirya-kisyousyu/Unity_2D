using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //�Q�[���N���A�A�Q�[���I�[�o�[�摜
    public Sprite gameClearImage;
    public Sprite gameOverImage;

    public GameObject mainImage;

    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���X�^�[�g�摜��1�b�ԕ\��
        Invoke("InActiveImage", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�Q�[���X�^�[�g�摜���\���ɂ���
    private void InActiveImage()
    {
        mainImage.SetActive(false);
    }

    //�X�^�[�g��ʂɖ߂�
    private void CallTitle()
    {
        SceneManager.LoadScene("StartScene");
    }

    //�Q�[���N���A
    public void GameClear()
    {
        //�Q�[���N���A�̕\��
        mainImage.GetComponent<Image>().sprite = gameClearImage;
        mainImage.SetActive(true);

        //�X�^�[�g��ʂɖ߂�
        Invoke("CallTitle", 2.0f);
    }

    //�Q�[���I�[�o�[
    public void GameOver()
    {
        //�Q�[���I�[�o�[�̕\��
        mainImage.GetComponent<Image>().sprite = gameOverImage;
        mainImage.SetActive(true);

        //�X�^�[�g��ʂɖ߂�
        Invoke("CallTitle", 2.0f);
    }
}
