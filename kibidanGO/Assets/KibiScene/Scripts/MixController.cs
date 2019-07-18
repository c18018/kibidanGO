using System.Collections;
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

        Invoke("Cancel", 5);

        Invoke("True", 6);
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

    /*public void OnClick()
    {
        Debug.Log("Button click");
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            counter++;
            if(counter >= counterMax)
            {
                Debug.Log("完成！");
                SceneManager.LoadScene("Finish");
            }
        }
    }
}
