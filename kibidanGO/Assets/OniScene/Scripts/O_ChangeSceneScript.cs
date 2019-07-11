using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class O_ChangeSceneScript : MonoBehaviour
{
    H_CheckInstanceScript instanceScript;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        H_CheckInstanceScript.haveDog = true;

        Invoke("TestChangeScene", 2.0f);
    }

    void TestChangeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
