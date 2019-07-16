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
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(scene_script.walk_co);
    }

    void CloudMove()
    {

    }
}
