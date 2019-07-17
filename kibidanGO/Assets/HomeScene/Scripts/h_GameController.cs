using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class h_GameController : MonoBehaviour
{
    h_SceneController scene_script;

    Image cloud1;
    Image cloud2;
    Image cloud3;

    // Start is called before the first frame update
    void Start()
    {
        scene_script = gameObject.GetComponentInChildren<h_SceneController>();
        // あとでTagを替える
        cloud1 = GameObject.Find("Cloud1").GetComponent<Image>();
        cloud2 = GameObject.Find("Cloud2").GetComponent<Image>();
        cloud3 = GameObject.Find("Cloud3").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CloudMove()
    {
        if(scene_script.test_co == 1)
        {

        }
    }
}
