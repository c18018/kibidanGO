using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class d_dangoOp : MonoBehaviour
{
    public GameObject dango;
    private Vector3 ScreenPos;//タップした地点のスクリーン座標
    private float dangoZ = 112.0f; //だんごの初期のZ位置


    private float distance;//フリックし始め、終わった位置の距離

    private float intervalZ = 0.0f;
    int dango_co = 0;

    AudioSource button;

    public Text dangoText = null;

    private Vector3[] trajectory = new Vector3[2];//２フレーム分の位置の配列

    GameObject targetObj = null;//標的になる物体
    private Vector3 target;//標的になる物体の位置

    private bool dango_op = true;//団子の操作をしていいかどうか

    private Vector3 dangoPos = new Vector3(0, -24, 112);
    GameObject master = null;
    public GameObject dog_relay = null;
    public int get_co = 0;

    public GameObject end_display = null;

    private void Start()
    {
        dango_op = true;
        dango.transform.position = dangoPos;
        master = GameObject.FindGameObjectWithTag("Master");
        dango_co = master.GetComponent<h_Master>().dango_co;
        dangoText.text = dango_co.ToString();
        button = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && dango_op) Dango_pos();
        if (Input.GetMouseButtonUp(0) && dango_op) Dango_throw();

        //if (Input.touchCount > 0) TapInput();

    }


    void TapInput()
    {
        Touch touch = Input.GetTouch(0);
        if (dango_op && touch.phase == TouchPhase.Moved) Dango_pos();
        if (dango_op && touch.phase == TouchPhase.Ended) Dango_throw();
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


        if (distance > 100)
        {
            target = targetObj.transform.position;
            intervalZ = 15.0f;
            target.z += distance;
            SetTarget(30);
        }
        else if (distance > 20)
        {

            target = targetObj.transform.position;
            intervalZ = 10.0f;
            SetTarget(30);
        }
        else if(distance > 5)
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
        if (dango_co > 0)
        {
            dango_co--;
            dangoText.text = dango_co.ToString();
            dango.SetActive(true);
            get_co = dog_relay.GetComponent<d_dogTarget>().get_co;
        }
        if (master.GetComponent<h_Master>().dog_co >= 3) master.GetComponent<h_Master>().DogStatus(); 
        dango_op = true;
    }
    

    public int DangoCount()
    {
        return dango_co;
    }
    

    public void DogEnd()
    {
        dango_op = false;
        end_display.SetActive(true);
    }

    public void returnButton()
    {
        dango_op = false;
        master.GetComponent<h_Master>().DogStatus();
        button.Play();
        Invoke("sceneRe", 0.5f);
    }

    private void sceneRe()
    {
        SceneManager.LoadScene("ARCamera");
    }
}
