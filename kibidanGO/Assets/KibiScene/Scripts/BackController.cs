using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackController : MonoBehaviour
{

    // Update is called once per frame
    public void OnClick()
    {
        GetComponent<AudioSource>().Play();
        Invoke("sceneRe", 0.5f);
    }

    private void sceneRe()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
