using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O_OniScript : MonoBehaviour
{
    // プレイヤースクリプト
    O_PlayerScript playerSc;

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
    // Animationを止める時間
    float stopTime;
    float startTime;
    
    float moveSpeed;

    [SerializeField] public AudioClip oni_sound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerSc = GameObject.FindGameObjectWithTag("GameController").GetComponent<O_PlayerScript>();

        oni_animator = GetComponent<Animator>();

        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
       
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
            Debug.Log("TurnController()");

            if(OniHP >= 150)
            {
                stopTime = 3.0f;
                startTime = 5.0f;
            }
            else if(OniHP >= 100)
            {
                stopTime = 2.0f;
                startTime = 4.0f;
            }
            else if(OniHP >= 50)
            {
                stopTime = 1.5f;
                startTime = 3.0f;
            }
            else
            {
                stopTime = 1.0f;
                startTime = 2.0f;
            }

            yield return new WaitForSeconds(2.0f);

            oni_attackPattern = Random.Range(1, 4);
            audioSource.PlayOneShot(oni_sound);

            Debug.Log("Random" + oni_attackPattern);

            if(oni_attackPattern == 1)
            {
                oni_animator.SetTrigger("upAttack");
                oni_upper = true;

                Invoke("OniAnimStop", stopTime);
                Invoke("OniAnimStart", startTime);
            }
            else if(oni_attackPattern == 2)
            {
                oni_animator.SetTrigger("mediumAttack");
                oni_middle = true;

                Invoke("OniAnimStop", stopTime);
                Invoke("OniAnimStart", startTime);
            }
            else if(oni_attackPattern == 3)
            {
                oni_animator.SetTrigger("underAttack");
                oni_lower = true;

                Invoke("OniAnimStop", stopTime);
                Invoke("OniAnimStart", startTime);
            }
            
            yield return playerSc.StartCoroutine("PlayerButtonSelect");
            
            oni_upper = false;
            oni_middle = false;
            oni_lower = false;

            playerSc.stop_text = false;

            // ボタンのハイライトの初期化
            playerSc.dog_button.interactable = false;
            playerSc.monkey_button.interactable = false;
            playerSc.pheasant_button.interactable = false;
        }
    }

    void OniAnimStop()
    {
        oni_animator.SetFloat("movingSpeed", 0.0f);
    }

    void OniAnimStart()
    {
        if (OniHP >= 150)
        {
            moveSpeed = 1.1f;
        }
        else if (OniHP >= 100)
            moveSpeed = 1.3f;
        else if (OniHP >= 50)
            moveSpeed = 1.6f;
        else
            moveSpeed = 1.8f;

            oni_animator.SetFloat("movingSpeed", moveSpeed);        
    }
}
