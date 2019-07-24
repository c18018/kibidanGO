using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnController : MonoBehaviour
{
    // Start is called before the first frame update
    h_Master Master;

    private void Start()
    {
        Master = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        Master.water = false;
        Master.sugar = false;
        Master.mochi = false;
    }

    public void OnClick()
    {
        Master.dango_co += 5;
        GetComponent<AudioSource>().Play();
        Invoke("sceneRe", 0.5f);
    }
    private void sceneRe()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
