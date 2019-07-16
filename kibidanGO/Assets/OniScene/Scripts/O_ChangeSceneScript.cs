using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class O_ChangeSceneScript : MonoBehaviour
{
    h_Master masterScript;
    
    // Start is called before the first frame update
    void Start()
    {
        masterScript = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
    }

    // Update is called once per frame
    void Update()
    {
        masterScript.Dog = true;
        Invoke("TestChangeScene", 2.0f);
    }

    void TestChangeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
