using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        Invoke("Call", 1);
    }

    void Call()
    {
        audioSource.PlayOneShot(sound1);
    }
}