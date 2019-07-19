using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject Kibidango2;
    public float shotSpeed;
    public float shotTotque;
    public int shotCount;

    // Use this for initialization
    void Start()
    {

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
}
