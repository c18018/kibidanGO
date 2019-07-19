using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZairyouController : MonoBehaviour
{
    float speed = 2.0f;
    float time = 0;

    public GameObject target;



    void Update()

    {
        time += Time.deltaTime;
        float step = speed * Time.deltaTime;


        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

    }

}