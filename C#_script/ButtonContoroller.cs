using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonContoroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ƒV[ƒ“‚ÌØ‚è‘Ö‚¦
    public void Change_Scene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
