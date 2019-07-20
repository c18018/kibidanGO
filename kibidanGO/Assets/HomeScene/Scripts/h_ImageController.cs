using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class h_ImageController : MonoBehaviour
{
    Image dog;
    Image monkey;
    Image pheasant;

    Image animal;
    float red, green, blue;
    
    h_Master masterScript;

    [SerializeField] public AudioClip[] sound = new AudioClip[3];
    AudioSource audioSource;
    bool oneshot = false;

    // Start is called before the first frame update
    void Start()
    {
        masterScript = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();

        dog = GameObject.FindGameObjectWithTag("Dog").GetComponent<Image>();
        monkey = GameObject.FindGameObjectWithTag("Monkey").GetComponent<Image>();
        pheasant = GameObject.FindGameObjectWithTag("Pheasant").GetComponent<Image>();

        if (masterScript.haveDog)
            dog.color = new Color(255, 255, 255);

        if (masterScript.haveMon)
            monkey.color = new Color(255, 255, 255);

        if (masterScript.havePhe)
            pheasant.color = new Color(255, 255, 255);

        oneshot = true;
    }

    // Update is called once per frame
    void Update()
    {
        AnimalGetComponent();
    }

    void AnimalGetComponent()
    {
        if (masterScript.Dog)
        {
            animal = dog;
            if(!masterScript.haveDog && animal != null)
                AnimalMove();

            if (oneshot && !masterScript.haveDog)
            {
                audioSource.PlayOneShot(sound[0]);
                oneshot = false;
            }

            if (red == 2.0f)
                masterScript.haveDog = true;
        }

        if (masterScript.Monkey)
        {
            animal = monkey;
            if (!masterScript.haveMon && animal != null)
                AnimalMove();

            if (oneshot && !masterScript.haveMon)
            {
                audioSource.PlayOneShot(sound[1]);
                oneshot = false;
            }

            if (red == 2.0f)
                masterScript.haveMon = true;
        }

        if (masterScript.Pheasant)
        {
            animal = pheasant;
            if (!masterScript.havePhe && animal != null)
                AnimalMove();

            if (oneshot && masterScript.havePhe)
            {
                audioSource.PlayOneShot(sound[2]);
                oneshot = false;
            }

            if (red == 2.0f)
                masterScript.havePhe = true;
        }
    }

    void AnimalMove()
    {
        red = animal.color.r;
        green = animal.color.g;
        blue = animal.color.b;

        animal.color = new Color(red + 0.01f, green + 0.01f, blue + 0.01f);
        if (red > 1.5f)
        {
            animal = null;
            red = 2.0f;
            green = 2.0f;
            blue = 2.0f;
        }
    }
}
