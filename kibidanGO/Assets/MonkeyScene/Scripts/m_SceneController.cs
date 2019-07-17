using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class m_SceneController : MonoBehaviour
{
    private GameObject master = null;
    public GameObject end_display = null;

    private void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master");
    }


    // さるを見つけたかどうか
    public bool Monkey()
    {
        Debug.Log(true);
        end_display.SetActive(true);
        return true;
    }

    public void returnButton()
    {
        //master.GetComponent<h_Master>().DogStatus();
        Invoke("sceneRe", 0.5f);
    }

    private void sceneRe()
    {
        SceneManager.LoadScene("ARCamera");
    }
}
