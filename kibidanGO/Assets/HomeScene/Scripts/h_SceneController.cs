using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class h_SceneController : MonoBehaviour
{
    //h_Master masterScript;

    // 動物を探しに行くボタン
    Button friendsButton;
    // ダンゴを作るボタン
    Button dangoButton;

    // テスト用ボタン
    Button testButton;
    // 雲を動かす(テスト用)
    public int test_co = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // 動物を持っているかの確認
        //masterScript = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        // あとでTagに替える
        friendsButton = GameObject.Find("FriendsButton").GetComponent<Button>();
        dangoButton = GameObject.Find("DangoButton").GetComponent<Button>();

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

    public void OnClickedDangoButton()
    {

    }

    // ARCameraシーンに遷移する
    void ChangeARCameraScene()
    {
        SceneManager.LoadScene("ARCamera");
        //walk_co += 1; 
    }

    public void OnClickedTestButton()
    {
        //SceneManager.LoadScene("OniScene");
        // 多分後で消すはず
        h_GameController.getComp = true;
        h_ImageController.getComp = true;
        test_co += 1;
    }


}
