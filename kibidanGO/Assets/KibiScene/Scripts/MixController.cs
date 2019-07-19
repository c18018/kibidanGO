﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MixController : MonoBehaviour
{

    private int counter = 0;
    const int counterMax = 5;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("False", 0);

        Invoke("Cancel", 3);

        Invoke("True", 4);
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

    // Update is called once per frame
    public void OnClick()
    {
        Debug.Log("clicked");

        counter++;
        if (counter >= counterMax)
        {
            Debug.Log("完成！");
            gameObject.SetActive(false);
            SceneManager.LoadScene("Kibi_Finish");
        }
    }
}
