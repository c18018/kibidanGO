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
    public int Animal_attack
    {
        get { return this.animal_attack; }
    }

    float player_waitTime;
    public float Player_waitTime
    {
        get { return this.player_waitTime; }
    }

    [System.NonSerialized] public bool waitTime_countStart = false;
    [System.NonSerialized] public bool getCountTime = false;
    [System.NonSerialized] public bool stop_text = false;

    Animator dog_animator, monkey_animator, pheasant_animator;

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
        //Debug.Log("d_: " + dog_onclick + " m_: " + monkey_onclick + " p_: " + pheasant_onclick);
    }

    // プレイヤーのボタン選択時間
    public IEnumerator PlayerButtonSelect()
    {
        Debug.Log("PlayerButtonSelect()");

        dog_onclick = false;
        monkey_onclick = false;
        pheasant_onclick = false;

        OniAttackSpeed();

        button_select = true;

        if (button_select)
        {
            dog_button.interactable = true;
            monkey_button.interactable = true;
            pheasant_button.interactable = true;

            waitTime_countStart = true;
            getCountTime = true;
            yield return new WaitForSeconds(player_waitTime);
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

        yield return StartCoroutine("AnimalAttack");
        gameSc.damage_log = false;
        stop_text = true;
        yield return new WaitForSeconds(2.0f);
    }

    // 動物の攻撃
    IEnumerator AnimalAttack()
    {
        Debug.Log("AnimalAttack()");
        gameSc.damage_log = true;
        if(dog_onclick && !oniSc.oni_lower)
        {
            dog_animator.SetTrigger("dogAttack");
            animal_attack = 10;
            oniSc.OniHP -= animal_attack;
            Debug.Log("いぬ　" + animal_attack);
        }
        else if(monkey_onclick && !oniSc.oni_middle)
        {
            monkey_animator.SetTrigger("saruAttack");
            animal_attack = 15;
            oniSc.OniHP -= animal_attack;
            Debug.Log("さる　" + animal_attack);
        }
        else if(pheasant_onclick && !oniSc.oni_upper)
        {
            //pheasant_animator.SetTrigger("");
            animal_attack = 20;
            oniSc.OniHP -= animal_attack;
            Debug.Log("きじ　" + animal_attack);
        }

        yield return new WaitForSeconds(2.0f);
    }

    //鬼の攻撃がだんだんはやくなる
    void OniAttackSpeed()
    {
        if (oniSc.OniHP >= 150)
            player_waitTime = 5.0f;
        else if (oniSc.OniHP >= 100)
            player_waitTime = 4.0f;
        else if (oniSc.OniHP >= 50)
            player_waitTime = 3.0f;
        else
            player_waitTime = 2.0f;

        // 鬼のHPが０になったら０にする
        if (oniSc.OniHP <= 0)
            oniSc.OniHP = 0;
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
}
