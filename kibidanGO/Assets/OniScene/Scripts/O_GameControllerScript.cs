using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O_GameControllerScript : MonoBehaviour
{
    float time = 0;
    O_OniScript oniSc;
    O_PlayerScript plaSc;

    string oniHp = "500";

    // Start is called before the first frame update
    void Start()
    {
        oniSc = GameObject.FindGameObjectWithTag("Oni").GetComponent<O_OniScript>();
        plaSc = GameObject.FindGameObjectWithTag("GameController").GetComponent<O_PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        time += 1 * Time.deltaTime;
        //Debug.Log((int)time);
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        GUI.Label(new Rect(1700, 100, 500, 300), System.Convert.ToString(oniSc.OniHP) + " / " + oniHp);
        GUI.Label(new Rect(100, 100, 500, 300), System.Convert.ToString((int)time));
    }
}
