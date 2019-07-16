using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class t_ButtonController : MonoBehaviour
{
    Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton = gameObject.GetComponentInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
