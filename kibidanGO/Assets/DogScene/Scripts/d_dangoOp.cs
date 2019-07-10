using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_dangoOp : MonoBehaviour
{
    public GameObject dango;
    private Vector3 ScreenPos;//タップした地点のスクリーン座標
    private float dangoZ = 112.0f; //だんごの初期のZ位置


    private float distance;//フリックし始め、終わった位置の距離

    private float intervalZ = 0.0f;


    private Vector3[] trajectory = new Vector3[2];//２フレーム分の位置の配列

    GameObject targetObj = null;//標的になる物体
    private Vector3 target;//標的になる物体の位置

    private bool dango_op = true;//団子の操作をしていいかどうか

    private Vector3 dangoPos = new Vector3(0, -24, 112);

    Touch touch;

    private void Start()
    {
        dango.transform.position = dangoPos;
    }

    void Update()
    {
        /*
        if (Input.GetMouseButton(0) && dango_op) Dango_pos();
        if (Input.GetMouseButtonUp(0) && dango_op) Dango_throw();
        */

        if (Input.touchCount > 0) {
            touch = Input.GetTouch(0);
        }
        switch (touch.phase)
        {
            case TouchPhase.Moved :
                if(dango_op) Dango_pos();
                break;

            case TouchPhase.Ended:
                if (dango_op) Dango_throw();
                break;
        }
    }


    //タップした地点に団子を移動
    void Dango_pos()
    {
        dango.transform.position = ScreenToWorld();
        trajectory[1] = trajectory[0];
        trajectory[0] = ScreenPos;
    }



    //スクリーン座標をワールド座標に変換
    Vector3 ScreenToWorld()
    {
        Vector3 worldPos;
        ScreenPos = Input.mousePosition;
        ScreenPos.z = dangoZ;
        worldPos = Camera.main.ScreenToWorldPoint(ScreenPos);
        return worldPos;
    }


    Vector3 flick_offset;//フリックの初めと終わりの地点の差

    //タップをやめた時
    void Dango_throw()
    {
        dango_op = false;
        flick_offset = trajectory[0] - trajectory[trajectory.Length - 1];
        distance = (trajectory[0] - trajectory[trajectory.Length - 1]).magnitude;
        targetObj = GameObject.FindGameObjectWithTag("Dog");
        
        if(targetObj == null)
        {
            target = dango.transform.position * 5;
            target.z += distance;
            SetTarget(30);
            Initialize();
            return;
        }


        if (distance > 50)
        {
            target = targetObj.transform.position;
            intervalZ = 15.0f;
            target.z += distance;
            SetTarget(30);
        }
        else if (distance > 5)
        {

            target = targetObj.transform.position;
            intervalZ = 10.0f;
            SetTarget(30);
        }
        else if (distance > 3)
        {
            target = targetObj.transform.position;
            intervalZ = 1.0f;
            target.z = (target.z - dangoZ)*distance*0.01f + dangoZ;
            SetTarget(30);
        }
        else
        {
            dango.SetActive(false);
            Invoke("DangoPos0", 0.5f);
        }

        Initialize();
    }



    //配列の初期化
    private void Initialize()
    {
        trajectory[0] = new Vector3(0, 0, 0);
        trajectory[1] = new Vector3(0, 0, 0);
    }



    private Vector3 offset;
    private float deg = 0;//射出角度

    //団子と標的の差など
    void SetTarget(float deg0)
    {
        offset = dango.transform.position;
        target -= offset;
        deg = deg0;
        StartCoroutine("Throw");
    }



    //団子の放物線
    IEnumerator Throw()
    {
        float x = 0.0f;
        float b = Mathf.Tan(deg * Mathf.Deg2Rad);
        float a = (target.y - b * target.z) / (target.z * target.z);

        for (float z = 0; z <= target.z; z += 10.0f)
        {
            float y = a * z * z + b * z;
            x += flick_offset.x/16.0f;
            dango.transform.position = new Vector3(x, y, z) + offset;
            yield return null;
        }
        
        dango.SetActive(false);
        Invoke("DangoPos0", 0.5f);
    }



    private void DangoPos0()
    {
        dango.transform.position = dangoPos;
        dango.SetActive(true);
        dango_op = true;
    }


    private void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        GUI.Label(new Rect(50, 100, 500, 300), System.Convert.ToString((int)distance));
    }
}
