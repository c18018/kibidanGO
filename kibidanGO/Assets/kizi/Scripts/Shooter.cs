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
    public Text shotCountText;

    AudioSource button;
    // Use this for initialization
    void Start()
    {
        Master = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        shotCount = Master.dango_co;
        shotCountText.text = shotCount.ToString();
        Debug.Log("trtrtr");
        button = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetButtonDown("Fire1")) Shot();

    }
    public void OnClick()
    {
        button.Play();
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
            shotCountText.text = shotCount.ToString();
            
            
           

        }
    }
    public void Return()
    {
        button.Play();
        Master.dango_co = shotCount;
        Invoke("returnScene", 0.5f);
    }

    void returnScene()
    {
        SceneManager.LoadScene("ARCamera");
    }
}
