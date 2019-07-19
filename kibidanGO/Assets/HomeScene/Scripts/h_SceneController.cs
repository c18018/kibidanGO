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
    // ダンゴの数を表示するテキスト
    Text dangoCo_text;

    [SerializeField] public AudioClip button_sound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        masterScript = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        // あとでTagに替える
        friendsButton = GameObject.Find("FriendsButton").GetComponent<Button>();
        dangoButton = GameObject.Find("DangoButton").GetComponent<Button>();
        // あとでTag替え
        dangoCo_text = GameObject.Find("DangoCount").GetComponent<Text>();
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        // ダンゴの数を表示
        DangoTextDisplay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 仲間を探すボタン
    public void OnClickedFriendsButton()
    {
        audioSource.PlayOneShot(button_sound);
        SceneManager.LoadScene("ARCamera");
    }

    // ダンゴボタン
    public void OnClickedDangoButton()
    {
        audioSource.PlayOneShot(button_sound);
        SceneManager.LoadScene("KibiScene");
    }

    // ダンゴの数テキスト表示
    void DangoTextDisplay()
    {
        dangoCo_text.text = System.Convert.ToString(masterScript.dango_co);
    }

    public void PanelEvent()
    {
        if (masterScript.Dog && masterScript.Monkey && masterScript.Pheasant)
            SceneManager.LoadScene("OniScene");
    }
}
