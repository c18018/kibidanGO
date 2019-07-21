using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class h_GameController : MonoBehaviour
{
    //h_SceneController scene_script;
    h_Master masterSc;

    bool getComp = false;

    Image cloud1;
    Image cloud2;
    Image cloud3;

    Image cloud;
    float red, green, blue, alfa;

    [SerializeField] public AudioClip cloud_sound;
    AudioSource audioSource;
    bool oneshot = false;

    // Start is called before the first frame update
    void Start()
    {
        masterSc = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();

        cloud1 = GameObject.FindGameObjectWithTag("Cloud1").GetComponent<Image>();
        cloud2 = GameObject.FindGameObjectWithTag("Cloud2").GetComponent<Image>();
        cloud3 = GameObject.FindGameObjectWithTag("Cloud3").GetComponent<Image>();

        if (masterSc.haveDog)
            cloud1.color = new Color(0, 0, 0, 0);

        if (masterSc.haveMon)
            cloud2.color = new Color(0, 0, 0, 0);

        if (masterSc.havePhe)
            cloud3.color = new Color(0, 0, 0, 0);

        oneshot = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(scene_script.test_co);
        //Debug.Log(getComp);
        ImageComponentGet();
    }

    void ImageComponentGet()
    {
        if (masterSc.Dog)
        {
            cloud = cloud1;
            if (!masterSc.haveDog && cloud != null)
                CloudMove();

            if(oneshot && !masterSc.haveDog)
            {
                audioSource.PlayOneShot(cloud_sound);
                oneshot = false;
            }
        }

        if (masterSc.Monkey)
        {
            cloud = cloud2;
            if (!masterSc.haveMon && cloud != null)
                CloudMove();

            if (oneshot && !masterSc.haveMon)
            {
                audioSource.PlayOneShot(cloud_sound);
                oneshot = false;
            }
        }

        if (masterSc.Pheasant)
        {
            cloud = cloud3;
            if (!masterSc.havePhe && cloud != null)
                CloudMove();

            if (oneshot && !masterSc.havePhe)
            {
                audioSource.PlayOneShot(cloud_sound);
                oneshot = false;
            }
        }
    }

    void CloudMove()
    {
        red = cloud.color.r;
        green = cloud.color.g;
        blue = cloud.color.b;
        alfa = cloud.color.a;

        cloud.color = new Color(red, green, blue, alfa - 0.01f);
        if (alfa < 0f)
        {
            alfa = -1.0f;
            cloud.enabled = false;
            cloud = null;
        }
    }
}
