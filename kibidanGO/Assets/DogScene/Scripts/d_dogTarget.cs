using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_dogTarget : MonoBehaviour
{

    GameObject appearObj = null;
    public int get_co = 0;

    bool dog_display = true; //犬のオブジェクトを表示していいかどうか

    public float nearest = 200.0f; //マーカーを読み取る最短の距離
    public float farthest = 1000.0f; //マーカーを読み取る最長の距離

    void Start()
    {
        appearObj = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        dog_display = transform.position.z < nearest || transform.position.z > farthest;

        if (dog_display && appearObj.activeSelf)
        {
            appearObj.SetActive(false);
        }else if(!dog_display && !appearObj.activeSelf)
        {
            appearObj.SetActive(true);
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Dango")
        {
            get_co++;
            GetComponent<AudioSource>().Play();
        }
    }
}
