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

    Image cloud;
    float red, green, blue, alfa;

    [SerializeField] public AudioClip cloud_sound;
    AudioSource audioSource;
    bool oneshot = false;

    // Start is called before the first frame update
    void Start()
    {
        //scene_script = gameObject.GetComponentInChildren<h_SceneController>();
        masterSc = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        // trueにできるかあとで確認
        if(masterSc.Dog || masterSc.Monkey || masterSc.Pheasant)
            getComp = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(scene_script.test_co);
        Debug.Log(getComp);
        ImageComponentGet();
    }

    void CloudMove()
    {
        
        if(cloud != null)
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
            // test_co を h_Master の動物取得に変更
            // あとでTagに変更
            if(masterSc.Dog)
            {
                cloud = GameObject.Find("Cloud1").GetComponent<Image>();
                oneshot = true;
            }
            else if(masterSc.Monkey)
            {
                cloud = GameObject.Find("Cloud2").GetComponent<Image>();
                oneshot = true;
            }
            else if(masterSc.Pheasant)
            {
                cloud = GameObject.Find("Cloud3").GetComponent<Image>();
                oneshot = true;
            }
            red = cloud.color.r;
            green = cloud.color.g;
            blue = cloud.color.b;
            alfa = cloud.color.a;
            getComp = false;
        }
        if (oneshot)
            audioSource.PlayOneShot(cloud_sound);

        oneshot = false;
        CloudMove();
    }
}
