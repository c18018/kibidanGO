using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    public GameObject Get_kizi;
    public GameObject Button;
    public GameObject cube;
    bool m_xPlus = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_xPlus)
        {
            transform.position += new Vector3(15f * Time.deltaTime, 0f, 0f);
            if (transform.position.x >= 55)
                m_xPlus = false;
        }
        else
        {
            transform.position -= new Vector3(15f * Time.deltaTime, 0f, 0f);
            if (transform.position.x <= -50)
                m_xPlus = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dango")
        {

            //gameObject.SetActive(false);
            Get_kizi.SetActive(true);
            Button.SetActive(false);
            cube.SetActive(false);


            Destroy(gameObject);
            //Debug.Log("kfkfkfkfkfk");
        }
    }
}
