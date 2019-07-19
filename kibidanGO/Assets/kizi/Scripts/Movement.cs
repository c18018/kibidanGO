using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

     float countTime = 0;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        countTime += Time.deltaTime;
        //print(time);
        if (countTime > 10)
        {
            
            //Debug.Log(countTime);
            float n = Random.Range(1, 2);
            if (n == 1)
            {
                transform.parent = GameObject.Find("Cube").transform;
                //Debug.Log("Cube");
            }
            else if (n == 2)
            {
                transform.parent = GameObject.Find("Cube(1)").transform;
                //Debug.Log("Cube(1)");
            }
            /*else if (n == 3)
            {
                transform.parent = GameObject.Find("Cube(2)").transform;
                Debug.Log("Cube(2)");
            }
            else if (n == 4)
            {
                transform.parent = GameObject.Find("Cube(3)").transform;
                Debug.Log("Cube(3)");
            }
            else if (n == 5)
            {
                transform.parent = GameObject.Find("Cube(4)").transform;
                Debug.Log("Cube(4)");
            }
            countTime = 0;*/
            countTime = 0;
        }
    }
}
