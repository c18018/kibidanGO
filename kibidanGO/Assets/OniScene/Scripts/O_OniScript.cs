using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O_OniScript : MonoBehaviour
{
    O_PlayerScript m_playerScript;

    private int m_oniHP = 500;
    public int OniHP
    {
        get { return this.m_oniHP; }
        set { this.m_oniHP = value; }
    }

    private int m_attackRandom = 0;
    Text m_attackText;

    [System.NonSerialized] public bool m_oniupper = false;
    [System.NonSerialized] public bool m_onimiddle = false;
    [System.NonSerialized] public bool m_onilower = false;
    
    // Start is called before the first frame update
    void Start()
    {
        m_playerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<O_PlayerScript>();
        m_attackText = GameObject.FindGameObjectWithTag("Player").GetComponent<Text>();
        m_attackText.text = "";

        StartCoroutine("TurnController");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("上： " + m_oniupper + "中： " + m_onimiddle + "下： " + m_onilower);
    }

    public IEnumerator TurnController()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            m_attackRandom = Random.Range(1, 4);

            if(m_attackRandom == 1)
            {
                m_oniupper = true;
                m_attackText.text = "　うえ　　からこうげきがくる!!";
            }
            else if(m_attackRandom == 2)
            {
                m_onimiddle = true;
                m_attackText.text = "まんなか　からこうげきがくる!!";
            }
            else if(m_attackRandom == 3)
            {
                m_onilower = true;
                m_attackText.text = "　した　　からこうげきがくる!!";
            }
            Debug.Log("Rand : " + m_attackRandom);
            yield return m_playerScript.StartCoroutine("PlayerButtonSelect");

            m_attackText.text = "";

            yield return new WaitForSeconds(2.0f);
            m_playerScript.PlayerAttack();


            m_oniupper = false;
            m_onimiddle = false;
            m_onilower = false;

            /*if (m_attackRandom == 1)
            {
                m_oniupper = true;

                yield return new WaitForSeconds(3.0f);

                m_playerScript.PlayerAttack();
                m_oniupper = false;
            }
            else if (m_attackRandom == 2)
            {
                m_onimiddle = true;

                yield return new WaitForSeconds(3.0f);

                m_playerScript.PlayerAttack();
                m_onimiddle = false;
            }
            else if (m_attackRandom == 3)
            {
                m_onilower = true;

                yield return new WaitForSeconds(3.0f);

                m_playerScript.PlayerAttack();
                m_onilower = false;
            }*/

            m_playerScript.dogButton.interactable = false;
            m_playerScript.monkeyButton.interactable = false;
            m_playerScript.pheasantButton.interactable = false;
        }
    }
}
