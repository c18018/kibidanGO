using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class o_OniScript : MonoBehaviour
{
    // プレイヤースクリプト
    o_PlayerScript playerSc;

    // 鬼のHP
    private int m_oniHP = 200;
    public int OniHP
    {
        get { return this.m_oniHP; }
        set { this.m_oniHP = value; }
    }

    // 鬼の攻撃パターン
    private int oni_attackPattern = 0;
    
    // 鬼がどこを攻撃しているか
    [System.NonSerialized] public bool oni_upper, oni_middle, oni_lower;

    Animator oni_animator;

    // Start is called before the first frame update
    void Start()
    {
        playerSc = GameObject.FindGameObjectWithTag("GameController").GetComponent<o_PlayerScript>();

        oni_animator = GetComponent<Animator>();
       
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
            yield return new WaitForSeconds(1.0f);
            oni_attackPattern = Random.Range(1, 4);
            Debug.Log("Random" + oni_attackPattern);
            if(oni_attackPattern == 1)
            {
                oni_animator.SetTrigger("upAttack");
                oni_upper = true;
            }
            else if(oni_attackPattern == 2)
            {
                oni_animator.SetTrigger("mediumAttack");
                oni_middle = true;
            }
            else if(oni_attackPattern == 3)
            {
                oni_animator.SetTrigger("underAttack");
                oni_lower = true;
            }
            
            yield return playerSc.StartCoroutine("PlayerButtonSelect");
            
            oni_upper = false;
            oni_middle = false;
            oni_lower = false;

            //m_playerScript.dogButton.interactable = false;
            //m_playerScript.monkeyButton.interactable = false;
            //m_playerScript.pheasantButton.interactable = false;
        }
    }
}
