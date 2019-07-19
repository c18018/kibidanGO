using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
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
    void Update()
    {
        
    }
}
