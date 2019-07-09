using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O_PlayerScript : MonoBehaviour
{
    O_OniScript m_oniScript;

    bool m_buttonSelect = false;
    [System.NonSerialized] public bool onDogButton = false;
    [System.NonSerialized] public bool onMonkeyButton = false;
    [System.NonSerialized] public bool onPheasantButton = false;

    [System.NonSerialized] public Button dogButton;
    [System.NonSerialized] public Button monkeyButton;
    [System.NonSerialized] public Button pheasantButton;

    int m_playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        m_oniScript = GameObject.FindGameObjectWithTag("Oni").GetComponent<O_OniScript>();

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
        Debug.Log("イヌ： " + onDogButton + "サル： " + onMonkeyButton + "キジ： " + onPheasantButton);
        Debug.Log(m_buttonSelect);
    }

    public void OnClickedDogButton()
    {
        if (m_buttonSelect)
        {
            onDogButton = true;
            onMonkeyButton = false;
            onPheasantButton = false;
        }

        // StartCoroutine("OnAnyButtonClick");
        //Debug.Log("イヌ : " + m_DogButton + m_onDogButton);
    }

    public void OnClickedMonkeyButton()
    {
        if (m_buttonSelect)
        {
            onDogButton = false;
            onMonkeyButton = true;
            onPheasantButton = false;
        }
        
        //Debug.Log("サル : " + m_MonkeyButton + m_onMonkeyButton);
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
        Debug.Log("PlayerButtonSelect Start");
        m_buttonSelect = true;

        dogButton.interactable = true;
        monkeyButton.interactable = true;
        pheasantButton.interactable = true;

        if (m_buttonSelect)
        {
            if(!onDogButton && !onMonkeyButton && !onPheasantButton)
            {
                yield return new WaitForSeconds(5.0f);

                m_buttonSelect = false;
                //Debug.Log("Stop");
            }
            else
            {
                onDogButton = false;
                onMonkeyButton = false;
                onPheasantButton = false;
                

                yield return new WaitForSeconds(5.0f);

                m_buttonSelect = false;
                //Debug.Log("Stop");
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
            Debug.Log("Stop");
        }



        yield return null;
    }
}
