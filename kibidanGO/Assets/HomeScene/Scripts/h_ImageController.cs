using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class h_ImageController : MonoBehaviour
{
    static public bool getComp = false;

    [SerializeField] Image animal;
    float red, green, blue, alfa;
    h_Master masterScript;

    // テスト用
    //h_SceneController sceneSc;
    
    // Start is called before the first frame update
    void Start()
    {
        masterScript = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        // テスト用
        //sceneSc = gameObject.GetComponentInChildren<h_SceneController>();
        // Startが毎回動くか確認する！
        //getComp = true;
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
            if (alfa < 1.0f)
                alfa += 1.0f * Time.deltaTime;

            if (alfa >= 1.0f)
                alfa = 1.0f;
        }
    }
    
    void AnimalGetComponent()
    {
        if (getComp)
        {
            if (masterScript.Dog == true)
            {
                animal = GameObject.FindGameObjectWithTag("Dog").GetComponent<Image>();
            }
            else if (masterScript.Monkey == true)
            {
                animal = GameObject.FindGameObjectWithTag("Monkey").GetComponent<Image>();
            }
            else if (masterScript.Pheasant == true)
            {
                // Tagをかえる!!!
                animal = GameObject.Find("Pheasant").GetComponent<Image>();
            }
            red = animal.color.r;
            green = animal.color.g;
            blue = animal.color.b;
            alfa = animal.color.a;
            getComp = false;
        }
        AnimalMove();
    }
}
