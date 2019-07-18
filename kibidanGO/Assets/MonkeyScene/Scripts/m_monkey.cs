using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_monkey : MonoBehaviour
{
    float timer = 0.0f;
    public float interval = 0.0f;// 何秒で移動するか

    private GameObject[] monkeyPos;// さるが移動する場所
    private bool Monkey = false;// さるを見つけたかどうか

    public GameObject SceneController = null;
    AudioSource monkey_voice;

    void Start()
    {
        monkeyPos = GameObject.FindGameObjectsWithTag("MonkeyPos");
        transform.position = monkeyPos[Random.Range(0, monkeyPos.Length)].transform.position;
        monkey_voice = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval && !Monkey) hidePos();


        if (Input.GetMouseButtonDown(0)) rayJudge();
    }



    //さるの隠れ場所を変更
    private void hidePos()
    {
        VoiceRing();
        transform.position = monkeyPos[Random.Range(0, monkeyPos.Length)].transform.position;
        timer = 0.0f;
    }


    //Rayを飛ばしす
    private void rayJudge()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Monkey")
            {
                Monkey = true;
                SceneController.GetComponent<m_SceneController>().Monkey();
            }
        }

    }

    void VoiceRing()
    {
        monkey_voice.Play();
    }
}
