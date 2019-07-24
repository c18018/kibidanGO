using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class m_SceneController : MonoBehaviour
{
    private GameObject masterObj = null;
    public GameObject end_display = null;
    private h_Master master;
    AudioSource button;

    private void Start()
    {
        masterObj = GameObject.FindGameObjectWithTag("Master");
        master = masterObj.GetComponent<h_Master>();
        button = GetComponent<AudioSource>();
    }


    // さるを見つけたかどうか
    public bool Monkey()
    {
        Debug.Log(true);
        end_display.SetActive(true);
        master.Monkey = true;
        return true;
    }

    public void returnButton()
    {
        button.Play();
        master.dango_co--;
        Invoke("sceneRe", 0.5f);
    }

    private void sceneRe()
    {
        SceneManager.LoadScene("ARCamera");
    }
}
