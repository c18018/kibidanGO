using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class t_ButtonController : MonoBehaviour
{
    Button startButton;

    [SerializeField] public AudioClip button_sound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        startButton = gameObject.GetComponentInChildren<Button>();
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickedStartButton()
    {
        audioSource.PlayOneShot(button_sound);
        Invoke("ChangeHome", 0.5f);
    }

    void ChangeHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
