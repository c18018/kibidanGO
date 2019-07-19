using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Shooter : MonoBehaviour
{

    public GameObject Kibidango2;
    public float shotSpeed;
    public float shotTotque;
    public int shotCount;
    h_Master Master;

    // Use this for initialization
    void Start()
    {
        Master = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        shotCount = Master.dango_co;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetButtonDown("Fire1")) Shot();

    }
    public void OnClick()
    {
        if (shotCount > 0)
        {

            //Debug.Log("jfgpejagpnfp");
            GameObject Kibidango = (GameObject)Instantiate(
                Kibidango2, transform.position, Quaternion.identity
                );
            Rigidbody KibidangoRigidBody = Kibidango.GetComponent<Rigidbody>();
            KibidangoRigidBody.AddForce(transform.forward * shotSpeed);
            KibidangoRigidBody.AddTorque(new Vector3(0, shotTotque, 0));

            if (shotCount < 1)
            {
                return;
            }

            shotCount -= 1;


        }
    }
    public void Return()
    {
        
        SceneManager.LoadScene("ARCamera");
        Master.dango_co = shotCount;
    }
}
