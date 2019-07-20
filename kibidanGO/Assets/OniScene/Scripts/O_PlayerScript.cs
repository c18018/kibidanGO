using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class o_PlayerScript : MonoBehaviour
{
    o_OniScript oniSc;
    o_GameControllerScript gameSc;

    bool button_select = false;
    [System.NonSerialized] public bool dog_onclick, monkey_onclick, pheasant_onclick;

    [System.NonSerialized] public Button dog_button, monkey_button, pheasant_button;

    int animal_attack;
    int Animal_attack
    {
        get { return this.animal_attack; }
    }

    float waitTime = 5.0f;

    [System.NonSerialized] public bool countTime = false;

    public Animator dog_animator, monkey_animator, pheasant_animator;

    // Start is called before the first frame update
    void Start()
    {
        // スクリプトを取得
        oniSc = GameObject.FindGameObjectWithTag("Oni").GetComponent<o_OniScript>();
        gameSc = gameObject.GetComponentInChildren<o_GameControllerScript>();

        // ボタンを取得
        dog_button = GameObject.FindGameObjectWithTag("DogButton").GetComponent<Button>();
        monkey_button = GameObject.FindGameObjectWithTag("MonkeyButton").GetComponent<Button>();
        pheasant_button = GameObject.FindGameObjectWithTag("PheasantButton").GetComponent<Button>();

        // Animatorを取得
        dog_animator = GameObject.FindGameObjectWithTag("Dog").GetComponent<Animator>();
        monkey_animator = GameObject.FindGameObjectWithTag("Monkey").GetComponent<Animator>();
        //pheasant_animator = GameObject.FindGameObjectWithTag("Pheasant").GetComponent<Animator>();

        dog_button.interactable = false;
        monkey_button.interactable = false;
        pheasant_button.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("d_: " + dog_onclick + " m_: " + monkey_onclick + " p_: " + pheasant_onclick);
    }

    public void OnClickedDogButton()
    {
            dog_onclick = true;
            monkey_onclick = false;
            pheasant_onclick = false;
    }

    public void OnClickedMonkeyButton()
    {
            dog_onclick = false;
            monkey_onclick = true;
            pheasant_onclick = false;
    }

    public void OnClickedPheasantButton()
    {
            dog_onclick = false;
            monkey_onclick = false;
            pheasant_onclick = true;
    }

    /*public void AnimatorSet()
    {
        Debug.Log("AnimatorSet()");
        if(onDogButton && !m_oniScript.m_onilower)
        {
            animator_dog = true;
            m_playerAttack = 5;
            Invoke("PlayerAttack", 0.5f);
            Debug.Log("イヌ　" + m_playerAttack + "ダメージ");
        }
        else if(onMonkeyButton && !m_oniScript.m_onimiddle)
        {
            animator_mon = true;
            m_playerAttack = 10;
            Invoke("PlayerAttack", 0.5f);
            Debug.Log("サル　" + m_playerAttack + "ダメージ");
        }
        else if(onPheasantButton && !m_oniScript.m_oniupper)
        {
            m_playerAttack = 20;
            Invoke("PlayerAttack", 0.5f);
            Debug.Log("キジ　" + m_playerAttack + "ダメージ");
        }

        onDogButton = false;
        onMonkeyButton = false;
        onPheasantButton = false;
    } */   

    /*void PlayerAttack()
    {
        m_oniScript.OniHP -= m_playerAttack;
    }*/

    public IEnumerator PlayerButtonSelect()
    {
        Debug.Log("PlayerButtonSelect()");

        dog_onclick = false;
        monkey_onclick = false;
        pheasant_onclick = false;

        button_select = true;

        if (button_select)
        {
            dog_button.interactable = true;
            monkey_button.interactable = true;
            pheasant_button.interactable = true;

            yield return new WaitForSeconds(5.0f);
            button_select = false;
        }

        if (!button_select)
        {
            if (dog_onclick)
            {
                monkey_button.interactable = false;
                pheasant_button.interactable = false;
            }
            else if (monkey_onclick)
            {
                dog_button.interactable = false;
                pheasant_button.interactable = false;
            }
            else if (pheasant_onclick)
            {
                dog_button.interactable = false;
                monkey_button.interactable = false;
            }
            else
            {
                dog_button.interactable = false;
                monkey_button.interactable = false;
                pheasant_button.interactable = false;
            }
        }
        

        yield return new WaitForSeconds(2.0f);
    }

    IEnumerator AnimalAttack()
    {
        return null;
    }
}
