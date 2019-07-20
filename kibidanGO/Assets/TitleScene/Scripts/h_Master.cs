using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class h_Master : MonoBehaviour
{
    [System.NonSerialized] public int dango_co = 10;

    [System.NonSerialized] public bool water = false;
    [System.NonSerialized] public bool mochi = false;
    [System.NonSerialized] public bool sugar = false;

    [SerializeField] public bool Dog = false;
    [SerializeField] public bool Monkey = false;
    [SerializeField] public bool Pheasant = false;

    // HomeSceneの動物を取れているかどうか
    [System.NonSerialized] public bool haveDog = false;
    [System.NonSerialized] public bool haveMon = false;
    [System.NonSerialized] public bool havePhe = false;

    GameObject relayObj;

    [System.NonSerialized] public int dog_co = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DogStatus()
    {
        ObjectGet();
        dango_co = relayObj.GetComponent<d_dangoOp>().DangoCount();
        dog_co = relayObj.GetComponent<d_dangoOp>().get_co;
        if (dog_co >= 3)
        {
            Dog = true;
        }

        Debug.Log("dango_co:" + dango_co);
        Debug.Log("dog_co:" + dog_co);
    }

    public void MonkeyStatus()
    {
        Monkey = true;
    }

    public void PheasantStatus()
    {
        Pheasant = true;
    }

    void ObjectGet()
    {
        relayObj = GameObject.FindGameObjectWithTag("Relay");
        Debug.Log(relayObj);
    }
}
