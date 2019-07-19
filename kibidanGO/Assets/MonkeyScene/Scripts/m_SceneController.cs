using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class m_SceneController : MonoBehaviour
{
    private GameObject master = null;
    public GameObject end_display = null;
    AudioSource button;

    private void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master");
        button = GetComponent<AudioSource>();
    }


    // さるを見つけたかどうか
    public bool Monkey()
    {
        Debug.Log(true);
        end_display.SetActive(true);
        master.GetComponent<h_Master>().MonkeyStatus();
        return true;
    }

    public void returnButton()
    {
        button.Play();
        Invoke("sceneRe", 0.5f);
    }

    private void sceneRe()
    {
        SceneManager.LoadScene("ARCamera");
    }
}
