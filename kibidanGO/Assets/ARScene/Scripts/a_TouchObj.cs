using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class a_TouchObj : MonoBehaviour
{
    private h_Master master = null;
    public Image mochi, water, sugar = null;

    AudioSource button;


    private void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        dangoAsset(mochi, master.mochi);
        dangoAsset(water, master.water);
        dangoAsset(sugar, master.sugar);
        button = GetComponent<AudioSource>();
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
            if(hit.collider.tag == "Dog")
            {
                SceneManager.LoadScene("DogScene");
            }

            if (hit.collider.tag == "Monkey")
            {
                SceneManager.LoadScene("MonkeyScene");
            }

            if (hit.collider.tag == "Pheasant")
            {
                SceneManager.LoadScene("kiji");
            }

            if (hit.collider.tag == "Mochi")
            {
                master.mochi = true;
                dangoAsset(mochi, master.mochi);
            }

            if (hit.collider.tag == "Water")
            {
                master.water = true;
                dangoAsset(water, master.water);
            }

            if (hit.collider.tag == "Sugar")
            {
                master.sugar = true;
                dangoAsset(sugar, master.sugar);
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
        button.Play();
        Invoke("sceneRe", 0.5f);
    }

    private void sceneRe()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
