using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class o_GameControllerScript : MonoBehaviour
{
    float time = 0;
    o_OniScript oniSc;
    o_PlayerScript plaSc;
    
    [System.NonSerialized] public float waitTime = 0;

    Text attackText;

    // Start is called before the first frame update
    void Start()
    {
        oniSc = GameObject.FindGameObjectWithTag("Oni").GetComponent<o_OniScript>();
        plaSc = GameObject.FindGameObjectWithTag("GameController").GetComponent<o_PlayerScript>();
        // あとでTagをかえる↓
        attackText = GameObject.FindGameObjectWithTag("Player").GetComponent<Text>();
        attackText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        ChangeText();
    }



    public void Timer()
    {
        waitTime -= 1 * Time.deltaTime;
    }

    void ChangeText()
    {
        if (oniSc.oni_upper)
        {
            attackText.text = " うえ　　からこうげきがくる!!";
            if (plaSc.countTime)
            {
                attackText.text = " うえ　　からこうげきがくる!!　" + (int)waitTime;
            }
        }
        else if (oniSc.oni_middle)
        {
            attackText.text = "まんなか　からこうげきがくる!!";
            if (plaSc.countTime)
            {
                //Timer();
                attackText.text = "まんなか　からこうげきがくる!!　" + (int)waitTime;
            }
        }
        else if (oniSc.oni_lower)
        {
            attackText.text = "　した　　からこうげきがくる!!";
            if (plaSc.countTime)
            {
                //Timer();
                attackText.text = "　した　　からこうげきがくる!!　" + (int)waitTime;
            }
        }
    }
}
