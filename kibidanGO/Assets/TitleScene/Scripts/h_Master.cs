using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class h_Master : MonoBehaviour
{
    [System.NonSerialized] public int dango_co = 0;

    [System.NonSerialized] public int water_co = 0;
    [System.NonSerialized] public int mochi_co = 0;
    [System.NonSerialized] public int sugar_co = 0;

    [System.NonSerialized] public bool Dog = false;
    [System.NonSerialized] public bool Monkey = false;
    [System.NonSerialized] public bool Pheasant = false;

    GameObject relayObj;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "DogScene") DogStatus();
    }

    void DogStatus()
    {
        ObjectGet();
        dango_co = relayObj.GetComponent<d_dangoOp>().DangoCount();
    }

    void ObjectGet()
    {
        relayObj = GameObject.FindGameObjectWithTag("Relay");
    }
}
