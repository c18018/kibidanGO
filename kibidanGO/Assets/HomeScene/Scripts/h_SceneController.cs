using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class h_SceneController : MonoBehaviour
{
    // 動物を探しに行くボタン
    Button friendsButton;
    // ダンゴを作るボタン
    Button dangoButton;

    //[System.NonSerialized] public int walk_co = 0;

    // テスト用ボタン
    Button testButton;
    
    // Start is called before the first frame update
    void Start()
    {
        // あとでTagに替える
        friendsButton = GameObject.Find("FriendsButton").GetComponent<Button>();
        //dangoButton = GameObject.FindGameObjectWithTag("DangoButton").GetComponent<Button>();

        // テスト用
        testButton = GameObject.FindGameObjectWithTag("Player").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickedFriendsButton()
    {
        ChangeARCameraScene();
    }

    // ARCameraシーンに遷移する
    void ChangeARCameraScene()
    {
        SceneManager.LoadScene("ARCamera");
        //walk_co += 1; 
    }

    public void OnClickedTestButton()
    {
        SceneManager.LoadScene("OniScene");
        //walk_co += 1;
    }
}
