using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class H_SceneControllerScript : MonoBehaviour
{
    Button friendsButton;
    Button dangoButton;

    // テスト用ボタン
    Button testButton;

    // ホームにいるかどうか
    bool isHomeScene = false;

    // 動物を持っているかどうか
    bool haveDog = false;
    bool haveMonkey = false;
    bool havePheasant = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        //friendsButton = GameObject.FindGameObjectWithTag("FriendsButton").GetComponent<Button>();
        //dangoButton = GameObject.FindGameObjectWithTag("DangoButton").GetComponent<Button>();

        // テスト用
        testButton = GameObject.FindGameObjectWithTag("Player").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        HomeSceneActive();

        OniSceneActive();
    }

    // あとでARのシーン遷移ができるか試す
    /*void ChangeARScene()
    {
        SceneManager.LoadScene("ARCamera");
    }*/

    void TestFlag()
    {

    }

    /*public void OnClickedFriendsButton()
    {

    }*/

    public void OnClickedTestButton()
    {
        SceneManager.LoadScene("OniScene");
    }

    void HomeSceneActive()
    {
        if (SceneManager.GetActiveScene().name == "HomeScene")
        {
            isHomeScene = true;
        }
        else
        {
            isHomeScene = false;
        }
        Debug.Log(isHomeScene);
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    void OniSceneActive()
    {
        if(SceneManager.GetActiveScene().name == "OniScene")
        {
            haveDog = true;

            Invoke("TestChangeScene", 2.0f);
        }
    }
    void TestChangeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
