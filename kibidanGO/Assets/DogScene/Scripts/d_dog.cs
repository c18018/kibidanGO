using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_dog : MonoBehaviour
{
    AudioSource dog_voice;

    private int interval = 0;
    private float timer = 0.0f;

    void Start()
    {
        dog_voice = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > interval)
        {
            interval = Random.Range(1, 7);
            VoiceRing();
            Debug.Log(interval);
            timer = 0.0f;
        }
    }

    void VoiceRing()
    {
        dog_voice.Play();
    }
}
