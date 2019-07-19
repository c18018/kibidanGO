using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Call",4);
    }

    void Call()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void OnClick()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
