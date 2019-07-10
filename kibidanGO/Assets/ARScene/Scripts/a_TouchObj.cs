using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class a_TouchObj : MonoBehaviour
{
    int MochiCount = 0;
    int WaterCount = 0;
    int SugerCount = 0;


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
                MochiCount++;
            }

            if (hit.collider.tag == "Water")
            {
                WaterCount++;
            }

            if (hit.collider.tag == "Suger")
            {
                SugerCount++;
            }

        }
        
    }
}
