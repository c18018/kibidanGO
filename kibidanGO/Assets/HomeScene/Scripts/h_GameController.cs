using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class h_GameController : MonoBehaviour
{
    h_SceneController scene_script;

    static public bool getComp = false;

    [SerializeField] public Image cloud;
    float red, green, blue, alfa;

    // Start is called before the first frame update
    void Start()
    {
        scene_script = gameObject.GetComponentInChildren<h_SceneController>();
        // あとで確認
        //getComp = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(scene_script.test_co);
        Debug.Log(getComp);
        ImageComponentGet();
    }

    void CloudMove()
    {
        
        if(SceneManager.GetActiveScene().name == "HomeScene" && cloud != null)
        {
            cloud.color = new Color(red, green, blue, alfa);
            if(alfa > 0f)
            {
                alfa -= 1f * Time.deltaTime;
                cloud.transform.Translate(1, 0, 0);
            }
                

            if (alfa <= 0f)
            {
                alfa = 0f;
                cloud.enabled = false;
            }
        }
    }

    void ImageComponentGet()
    {
        if (getComp)
        {
            // あとでTagに変更
            if(scene_script.test_co == 1)
            {
                cloud = GameObject.Find("Cloud1").GetComponent<Image>();
            }
            else if(scene_script.test_co == 2)
            {
                cloud = GameObject.Find("Cloud2").GetComponent<Image>();
            }
            else if(scene_script.test_co == 3)
            {
                cloud = GameObject.Find("Cloud3").GetComponent<Image>();
            }
            red = cloud.color.r;
            green = cloud.color.g;
            blue = cloud.color.b;
            alfa = cloud.color.a;
            getComp = false;
        }
        CloudMove();
    }
}
