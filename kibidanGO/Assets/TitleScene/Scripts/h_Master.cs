using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class h_Master : MonoBehaviour
{
    [System.NonSerialized] public int dango_co = 10;

    [System.NonSerialized] public int water_co = 0;
    [System.NonSerialized] public int mochi_co = 0;
    [System.NonSerialized] public int sugar_co = 0;

    [System.NonSerialized] public bool Dog = false;
    [System.NonSerialized] public bool Monkey = false;
    [System.NonSerialized] public bool Pheasant = false;

    GameObject relayObj;
    bool findObj = true;

    int dog_co = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "DogScene") DogStatus();

        if(SceneManager.GetActiveScene().name == "ARCamera")
        {
            //findObj = true;
            Debug.Log("ARCamera dango_co:" + dango_co);
            Debug.Log("ARCamera dog_co:" + dog_co);
        }
    }

    public void DogStatus()
    {
        ObjectGet();
        dango_co = relayObj.GetComponent<d_dangoOp>().DangoCount();
        dog_co = relayObj.GetComponent<d_dangoOp>().get_co;
        if (dog_co >= 3)
        {
            Dog = true;
            relayObj.GetComponent<d_dangoOp>().DogEnd();
        }

        Debug.Log("dango_co:" + dango_co);
        Debug.Log("dog_co:" + dog_co);
    }

    void ObjectGet()
    {
        relayObj = GameObject.FindGameObjectWithTag("Relay");
        findObj = false;
        Debug.Log(relayObj);
    }
}
