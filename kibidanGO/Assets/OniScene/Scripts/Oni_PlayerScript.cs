using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni_PlayerScript : MonoBehaviour
{
    Oni_OniScript m_oniScript;

    [System.NonSerialized] public bool m_onDogButton = false;
    [System.NonSerialized] public bool m_onMonkeyButton = false;
    [System.NonSerialized] public bool m_onPheasantButton = false;

    int m_playerAttack;
    
    // Start is called before the first frame update
    void Start()
    {
        m_oniScript = GameObject.FindGameObjectWithTag("Oni").GetComponent<Oni_OniScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("イヌ： " + m_onDogButton + "サル： " + m_onMonkeyButton + "キジ： " + m_onPheasantButton);
    }

    public void OnClickedDogButton()
    {
        m_onDogButton = true;
        m_onMonkeyButton = false;
        m_onPheasantButton = false;
        // StartCoroutine("OnAnyButtonClick");
        Debug.Log("イヌ");
    }

    public void OnClickedMonkeyButton()
    {
        m_onDogButton = false;
        m_onMonkeyButton = true;
        m_onPheasantButton = false;
        Debug.Log("サル");
    }

    public void OnClickedPheasantButton()
    {
        m_onDogButton = false;
        m_onMonkeyButton = false;
        m_onPheasantButton = true;
        Debug.Log("キジ");
    }

    void PlayerAttack()
    {
        if(m_onDogButton && !m_oniScript.m_onilower)
        {
            m_playerAttack = 5;
            m_oniScript.OniHP -= m_playerAttack;
            Debug.Log("イヌ　" + m_playerAttack + "ダメージ");
        }
    }

    /* IEnumerator OnAnyButtonClick()
    {
        Debug.Log("PlaCor Start");
        if (m_onDogButton && !m_onMonkeyButton && !m_onPheasantButton)
        {
            yield return m_oniScript.StartCoroutine("OniAttackRandom");
        }
        else if (m_onMonkeyButton)
        {
            yield return new WaitForSeconds(2.0f);
        }
        else if (m_onPheasantButton)
        {
            yield return new WaitForSeconds(2.0f);
        }
    } */
}
