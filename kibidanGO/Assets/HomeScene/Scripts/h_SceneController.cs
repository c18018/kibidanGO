using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class h_SceneController : MonoBehaviour
{
    h_Master masterScript;

    // 動物を探しに行くボタン
    Button friendsButton;
    // ダンゴを作るボタン
    Button dangoButton;

    Text dangoCo_text;

    // Start is called before the first frame update
    void Start()
    {
        masterScript = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        // あとでTagに替える
        friendsButton = GameObject.Find("FriendsButton").GetComponent<Button>();
        dangoButton = GameObject.Find("DangoButton").GetComponent<Button>();
        // あとでTag替え
        dangoCo_text = GameObject.Find("DangoCount").GetComponent<Text>();
        DangoTextDisplay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 仲間を探すボタン
    public void OnClickedFriendsButton()
    {
        SceneManager.LoadScene("ARCamera");
    }

    // ダンゴボタン
    public void OnClickedDangoButton()
    {
        SceneManager.LoadScene("KibiScene");
    }

    void DangoTextDisplay()
    {
        dangoCo_text.text = System.Convert.ToString(masterScript.dango_co);
    }
}
