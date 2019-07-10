using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O_OniScript : MonoBehaviour
{
    O_PlayerScript m_playerScript;

    private int m_oniHP = 200;
    public int OniHP
    {
        get { return this.m_oniHP; }
        set { this.m_oniHP = value; }
    }

    private int m_attackRandom = 0;
    
    [System.NonSerialized] public bool m_oniupper = false;
    [System.NonSerialized] public bool m_onimiddle = false;
    [System.NonSerialized] public bool m_onilower = false;
    
    // Start is called before the first frame update
    void Start()
    {
        m_playerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<O_PlayerScript>();
       
        StartCoroutine("TurnController");
    }

    // Update is called once per frame
    void Update()
    {

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
            }
            else if(m_attackRandom == 2)
            {
                m_onimiddle = true;
            }
            else if(m_attackRandom == 3)
            {
                m_onilower = true;
            }

            yield return new WaitForSeconds(1.0f);

            yield return m_playerScript.StartCoroutine("PlayerButtonSelect");

            yield return new WaitForSeconds(2.0f);
            
            m_playerScript.PlayerAttack();


            m_oniupper = false;
            m_onimiddle = false;
            m_onilower = false;

            m_playerScript.dogButton.interactable = false;
            m_playerScript.monkeyButton.interactable = false;
            m_playerScript.pheasantButton.interactable = false;
        }
    }
}
