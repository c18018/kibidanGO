using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("False", 0);

        Invoke("Cancel", 3);

        Invoke("True", 3);
    }

    void False()
    {
        gameObject.SetActive(false);
    }

    void Cancel()
    {
        CancelInvoke("Call");
    }

    void True()
    {
        gameObject.SetActive(true);
    }

    public void OnClick()
    {
        SceneManager.LoadScene("HomeScene");
    }

}
