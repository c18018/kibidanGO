using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZairyouController : MonoBehaviour
{
    float speed = 4.0f;
    float time = 0;

    public GameObject target;

    void Start()
    {
        Invoke("False",3);
    }

    void Update()

    {
        time += Time.deltaTime;
        float step = speed * Time.deltaTime;


        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

    }

    void False()
    {
        Destroy(gameObject);
    }

}