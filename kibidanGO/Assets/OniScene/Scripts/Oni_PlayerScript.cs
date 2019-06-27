using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni_PlayerScript : MonoBehaviour
{
    Oni_OniScript m_oniScript;

    // Start is called before the first frame update
    void Start()
    {
        m_oniScript = GameObject.FindGameObjectWithTag("Oni").GetComponent<Oni_OniScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickDogButton()
    {
        Debug.Log("イヌ");
    }

    public void OnClickMonkeyButton()
    {
        Debug.Log("サル");
    }

    public void OnClickPheasantButton()
    {
        Debug.Log("キジ");
    }
}
