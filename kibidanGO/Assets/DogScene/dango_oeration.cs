using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dango_oeration : MonoBehaviour
{
    public GameObject dango;
    private Vector3 ScreenPos;//タップした地点のスクリーン座標


    private float distance;//フリックし始め、終わった位置の距離


    private Vector3[] trajectory = new Vector3[2];//２フレーム分の位置の配列

    GameObject targetObj = null;//標的になる物体
    private Vector3 target;//標的になる物体の位置

    private bool dango_op = true;//団子の操作をしていいかどうか



    void Update()
    {

        /*if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase) {

                case TouchPhase.Began:
                    Dango_display();
                    break;

                case TouchPhase.Moved:
                    Dango_pos();
                    break;

                case TouchPhase.Ended:
                    Dango_throw();
                    break;
            }
        }*/


        if (Input.GetMouseButtonDown(0) && dango_op) Dango_display();
        if (Input.GetMouseButton(0) && dango_op) Dango_pos();
        if (Input.GetMouseButtonUp(0) && dango_op) Dango_throw();
    }



    //タップしたら団子を表示
    void Dango_display()
    {
        dango.SetActive(true);
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
        ScreenPos.z = 500.0f;
        worldPos = Camera.main.ScreenToWorldPoint(ScreenPos);
        return worldPos;
    }



    //タップをやめた時
    void Dango_throw()
    {
        dango_op = false;
        distance = (trajectory[0] - trajectory[trajectory.Length - 1]).magnitude;
        targetObj = GameObject.FindGameObjectWithTag("Dog");
        Debug.Log(distance);

        //一つ前のフレームの位置との差が10より大きければフリックとみなす
        if (distance > 200)
        {
            target = targetObj.transform.position;
            target.z += distance;
            SetTarget(60);
        }
        else if (distance > 20)
        {

            target = targetObj.transform.position;
            SetTarget(60);
        }
        else if (distance > 3)
        {
            target = targetObj.transform.position;
            target.z *= distance * 0.1f;
            SetTarget(60);
        }
        else
        {
            dango.SetActive(false);
            dango_op = true;
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
        float b = Mathf.Tan(deg * Mathf.Deg2Rad);
        float a = (target.y - b * target.z) / (target.z * target.z);

        for (float z = 0; z <= target.z; z += 5.0f)
        {
            float y = a * z * z + b * z;
            dango.transform.position = new Vector3(0, y, z) + offset;
            yield return null;
        }

        dango.SetActive(false);
        dango_op = true;
    }


}
