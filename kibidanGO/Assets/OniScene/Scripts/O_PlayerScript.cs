using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O_PlayerScript : MonoBehaviour
{
    O_OniScript m_oniScript;
    O_GameControllerScript m_gameConScript;

    bool m_buttonSelect = false;
    [System.NonSerialized] public bool onDogButton = false;
    [System.NonSerialized] public bool onMonkeyButton = false;
    [System.NonSerialized] public bool onPheasantButton = false;

    [System.NonSerialized] public Button dogButton;
    [System.NonSerialized] public Button monkeyButton;
    [System.NonSerialized] public Button pheasantButton;

    int m_playerAttack;

    float waitTime = 5.0f;

    [System.NonSerialized] public bool countTime = false;

    // Start is called before the first frame update
    void Start()
    {
        m_oniScript = GameObject.FindGameObjectWithTag("Oni").GetComponent<O_OniScript>();
        m_gameConScript = gameObject.GetComponentInChildren<O_GameControllerScript>();

        dogButton = GameObject.Find("DogButton").GetComponent<Button>();
        monkeyButton = GameObject.Find("MonkeyButton").GetComponent<Button>();
        pheasantButton = GameObject.Find("PheasantButton").GetComponent<Button>();

        dogButton.interactable = false;
        monkeyButton.interactable = false;
        pheasantButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (countTime)
            m_gameConScript.Timer();

        if (m_oniScript.OniHP <= 0)
            m_oniScript.OniHP = 0;
    }

    public void OnClickedDogButton()
    {
        if (m_buttonSelect)
        {
            onDogButton = true;
            onMonkeyButton = false;
            onPheasantButton = false;
        }
    }

    public void OnClickedMonkeyButton()
    {
        if (m_buttonSelect)
        {
            onDogButton = false;
            onMonkeyButton = true;
            onPheasantButton = false;
        }
    }

    public void OnClickedPheasantButton()
    {
        if (m_buttonSelect)
        {
            onDogButton = false;
            onMonkeyButton = false;
            onPheasantButton = true;
        }
    }

    public void PlayerAttack()
    {
        if(onDogButton && !m_oniScript.m_onilower)
        {
            m_playerAttack = 5;
            m_oniScript.OniHP -= m_playerAttack;
            Debug.Log("イヌ　" + m_playerAttack + "ダメージ");
        }
        else if(onMonkeyButton && !m_oniScript.m_onimiddle)
        {
            m_playerAttack = 10;
            m_oniScript.OniHP -= m_playerAttack;
            Debug.Log("サル　" + m_playerAttack + "ダメージ");
        }
        else if(onPheasantButton && !m_oniScript.m_oniupper)
        {
            m_playerAttack = 20;
            m_oniScript.OniHP -= m_playerAttack;
            Debug.Log("キジ　" + m_playerAttack + "ダメージ");
        }

        onDogButton = false;
        onMonkeyButton = false;
        onPheasantButton = false;
    }    

    public IEnumerator PlayerButtonSelect()
    {
        m_buttonSelect = true;

        dogButton.interactable = true;
        monkeyButton.interactable = true;
        pheasantButton.interactable = true;

        waitTime = 5.0f;
        m_gameConScript.waitTime = 6.0f;

        if (m_oniScript.OniHP <= 150)
        {
            waitTime = 4.0f;
            m_gameConScript.waitTime = 5.0f;
        }

        if (m_oniScript.OniHP <= 100)
        {
            waitTime = 3.0f;
            m_gameConScript.waitTime = 4.0f;
        }

        if (m_oniScript.OniHP <= 50)
        {
            waitTime = 2.0f;
            m_gameConScript.waitTime = 3.0f;
        }

        if (m_buttonSelect)
        {
            if(!onDogButton && !onMonkeyButton && !onPheasantButton)
            {
                countTime = true;
                yield return new WaitForSeconds(waitTime);

                countTime = false;
                m_buttonSelect = false;
            }
            else
            {
                onDogButton = false;
                onMonkeyButton = false;
                onPheasantButton = false;

                countTime = true;
                yield return new WaitForSeconds(waitTime);

                countTime = false;
                m_buttonSelect = false;
            }

            if (onDogButton)
            {
                monkeyButton.interactable = false;
                pheasantButton.interactable = false;
            }
            else if (onMonkeyButton)
            {
                dogButton.interactable = false;
                pheasantButton.interactable = false;
            }
            else if (onPheasantButton)
            {
                dogButton.interactable = false;
                monkeyButton.interactable = false;
            }
            else
            {
                dogButton.interactable = false;
                monkeyButton.interactable = false;
                pheasantButton.interactable = false;
            }
        }
    }
}
