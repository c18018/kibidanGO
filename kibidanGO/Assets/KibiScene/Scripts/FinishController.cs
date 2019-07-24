using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    h_Master Master;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("False", 0);

        Invoke("Cancel", 1);

        Invoke("True", 1);

        Master = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        Master.water = false;
        Master.sugar = false;
        Master.mochi = false;
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
