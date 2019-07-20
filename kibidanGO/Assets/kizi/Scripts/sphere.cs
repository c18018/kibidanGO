using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    public GameObject Get_kizi;
    public GameObject Button;
    public GameObject cube;
    bool m_xPlus = true;
    h_Master Master;
    private Vector3 Player_pos;

    // Start is called before the first frame update
    void Start()
    {
        Master = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        Player_pos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_xPlus)
        {
            transform.position += new Vector3(30f * Time.deltaTime, 0f, 0f);
            if (transform.position.x >= 100)
                m_xPlus = false;
        }
        else
        {
            transform.position -= new Vector3(30f * Time.deltaTime, 0f, 0f);
            if (transform.position.x <= -100)
                m_xPlus = true;
        }
        Vector3 diff = transform.position - Player_pos;

        if (diff.magnitude > 0.01f) //ベクトルの長さが0.01fより大きい場合にプレイヤーの向きを変える処理を入れる(0では入れないので）
        {
            transform.rotation = Quaternion.LookRotation(diff);  //ベクトルの情報をQuaternion.LookRotationに引き渡し回転量を取得しプレイヤーを回転させる
        }

        Player_pos = transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dango")
        {

            gameObject.SetActive(false);
            Get_kizi.SetActive(true);
            Button.SetActive(false);
            cube.SetActive(false);
            Master.PheasantStatus();


            //Destroy(gameObject);
            //Debug.Log("kfkfkfkfkfk");
        }
    }
}
