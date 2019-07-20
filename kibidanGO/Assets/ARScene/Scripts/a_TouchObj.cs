using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class a_TouchObj : MonoBehaviour
{
    private h_Master master = null;
    public Image mochi, water, sugar = null;

    AudioSource audio;
    public AudioClip button;
    public AudioClip mateGet;

    bool dogScene = true;
    bool monkeyScene = true;
    bool kijiScene = true;
    bool mochiTf, waterTf, sugarTf = true;


    private void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        dangoAsset(mochi, master.mochi);
        dangoAsset(water, master.water);
        dangoAsset(sugar, master.sugar);
        audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) rayJudge();
    }



    private void rayJudge()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            dogScene = !master.Dog;
            monkeyScene = !master.Monkey;
            kijiScene = !master.Pheasant;
            mochiTf = !master.mochi;
            waterTf = !master.water;
            sugarTf = !master.sugar;


            if(hit.collider.tag == "Dog" && dogScene)
            {
                SceneManager.LoadScene("DogScene");
            }

            if (hit.collider.tag == "Monkey" && monkeyScene)
            {
                SceneManager.LoadScene("MonkeyScene");
            }

            if (hit.collider.tag == "Pheasant" && kijiScene)
            {
                SceneManager.LoadScene("kizi");
            }

            if (hit.collider.tag == "Mochi" && mochiTf)
            {
                master.mochi = true;
                dangoAsset(mochi, master.mochi);
                audio.PlayOneShot(mateGet);
            }

            if (hit.collider.tag == "Water" && waterTf)
            {
                master.water = true;
                dangoAsset(water, master.water);
                audio.PlayOneShot(mateGet);
            }

            if (hit.collider.tag == "Sugar" && sugarTf)
            {
                master.sugar = true;
                dangoAsset(sugar, master.sugar);
                audio.PlayOneShot(mateGet);
            }

        }
        
    }

    void dangoAsset(Image material, bool tf)
    {
        if (tf)
        {
            material.color = new Color(255, 255, 255, 1);
        }
        else
        {
            material.color = new Color(0, 0, 0, 1);
        }
    }


    public void returnButton()
    {
        audio.PlayOneShot(button);
        Invoke("sceneRe", 0.5f);
    }

    private void sceneRe()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
