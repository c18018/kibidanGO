using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class h_ImageController : MonoBehaviour
{
    bool getComp = false;

    [SerializeField] Image animal;
    float red, green, blue, alfa;
    h_Master masterScript;

    // テスト用
    //h_SceneController sceneSc;

    [SerializeField] public AudioClip[] audioClip = new AudioClip[3];
    AudioClip sound;
    AudioSource audioSource;
    bool oneshot = false;

    // Start is called before the first frame update
    void Start()
    {
        masterScript = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        // テスト用
        //sceneSc = gameObject.GetComponentInChildren<h_SceneController>();
        // Startが毎回動くか確認する！
        if(masterScript.Dog || masterScript.Monkey || masterScript.Pheasant)
            getComp = true;
    }

    // Update is called once per frame
    void Update()
    {
        AnimalGetComponent();
    }

    void AnimalMove()
    {
        if(animal != null)
        {
            animal.color = new Color(red, blue, green, alfa);
            
            if (red < 1.0f)
            {
                red += 1.0f * Time.deltaTime;
                green += 1.0f * Time.deltaTime;
                blue += 1.0f * Time.deltaTime;
            }
                
        }
    }
    
    void AnimalGetComponent()
    {
        if (getComp)
        {
            if (masterScript.Dog)
            {
                animal = GameObject.FindGameObjectWithTag("Dog").GetComponent<Image>();
                sound = audioClip[0];
                oneshot = true;
            }
            else if (masterScript.Monkey)
            {
                animal = GameObject.FindGameObjectWithTag("Monkey").GetComponent<Image>();
                sound = audioClip[1];
                oneshot = true;
            }
            else if (masterScript.Pheasant)
            {
                animal = GameObject.FindGameObjectWithTag("Pheasant").GetComponent<Image>();
                sound = audioClip[2];
                oneshot = true;
            }
            red = animal.color.r;
            green = animal.color.g;
            blue = animal.color.b;
            alfa = animal.color.a;
            getComp = false;
        }
        if(oneshot)
            audioSource.PlayOneShot(sound);
        
        oneshot = false;
        AnimalMove();
    }
}
