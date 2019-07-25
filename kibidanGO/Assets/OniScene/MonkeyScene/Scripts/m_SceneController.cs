using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class m_SceneController : MonoBehaviour
{
    private GameObject masterObj = null;
    public GameObject end_display = null;
    private h_Master master;
    [System.NonSerialized] public int dango_co;

    public Text dangoCountText = null;
    AudioSource button;

    private void Start()
    {
        masterObj = GameObject.FindGameObjectWithTag("Master");
        master = masterObj.GetComponent<h_Master>();
        dango_co = master.dango_co;
        dangoCountText.text = dango_co.ToString();
        button = GetComponent<AudioSource>();
    }


    // さるを見つけたかどうか
    public bool Monkey()
    {
        dango_co--;
        dangoCountText.text = dango_co.ToString();
        end_display.SetActive(true);
        master.Monkey = true;
        return true;
    }

    public void returnButton()
    {
        button.Play();
        master.dango_co = dango_co;
        Invoke("sceneRe", 0.5f);
    }

    private void sceneRe()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
