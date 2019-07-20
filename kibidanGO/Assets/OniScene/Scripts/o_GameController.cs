using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class o_GameController : MonoBehaviour
{
    GameObject oni, dog, monkey, pheasant;
    // 鬼の体力
    int oni_hp = 200;
    // 鬼の攻撃パターン
    int oni_attackpattern = 0;
    // 鬼の攻撃箇所
    bool oni_upper, oni_middle, oni_under;

    // いぬ、さる、きじのボタン
    Button dog_button, monkey_button, pheasant_button;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
