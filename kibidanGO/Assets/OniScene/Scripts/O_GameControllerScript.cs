using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class o_GameControllerScript : MonoBehaviour
{
    float waitTime;
    float time = 0;
    o_OniScript oniSc;
    o_PlayerScript playerSc;

    Text log_text;
    [System.NonSerialized] public bool damage_log = false;

    // Start is called before the first frame update
    void Start()
    {
        oniSc = GameObject.FindGameObjectWithTag("Oni").GetComponent<o_OniScript>();
        playerSc = GameObject.FindGameObjectWithTag("GameController").GetComponent<o_PlayerScript>();
        // あとでTagをかえる↓
        log_text = GameObject.FindGameObjectWithTag("Player").GetComponent<Text>();
        log_text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        ChangeText();
        Timer();
    }

    void ChangeText()
    {
        if (oniSc.oni_upper)
        {
            log_text.text = "　うえ　　からこうげき";
            if (playerSc.waitTime_countStart)
            {
                log_text.text = "　うえ　　からこうげき　" + (int)time;
            }
        }
        else if (oniSc.oni_middle)
        {
            log_text.text = "まんなか　からこうげき";
            if (playerSc.waitTime_countStart)
            {
                log_text.text = "まんなか　からこうげき　" + (int)time;
            }
        }
        else if (oniSc.oni_lower)
        {
            log_text.text = "　した　　からこうげき";
            if (playerSc.waitTime_countStart)
            {
                log_text.text = "　した　　からこうげき　" + (int)time;
            }
        }

        if (damage_log)
        {
            log_text.text = " オニに　" + playerSc.Animal_attack + "ダメージ！！";
        }

        if (playerSc.stop_text)
            log_text.text = "";
    }

    void Timer()
    {
        waitTime = playerSc.Player_waitTime;

        if (playerSc.getCountTime)
        {
            time = waitTime + 1.0f;
            playerSc.getCountTime = false;
        }

        time -= Time.deltaTime;

        if (time <= 1.0f)
        {
            time = 0.0f;
            playerSc.waitTime_countStart = false;
        }
    }
}
