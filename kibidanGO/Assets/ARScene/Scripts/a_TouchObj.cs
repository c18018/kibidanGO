using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class a_TouchObj : MonoBehaviour
{
    private h_Master master = null;
    public GameObject mochi, water, sugar = null;


    private void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
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
                SceneManager.LoadScene("PheasantScene");
            }

            if (hit.collider.tag == "Mochi")
            {
                //master.mochi = true;
            }

            if (hit.collider.tag == "Water")
            {
                //master.water = true;
            }

            if (hit.collider.tag == "Sugar")
            {
                //master.sugar = true;
            }

        }
        
    }


    public void returnButton()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
