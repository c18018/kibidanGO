using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class h_Master : MonoBehaviour
{
    [System.NonSerialized] public int dango_co = 0;

    [System.NonSerialized] public int water_co = 0;
    [System.NonSerialized] public int mochi_co = 0;
    [System.NonSerialized] public int sugar_co = 0;

    [System.NonSerialized] public bool Dog = false;
    [System.NonSerialized] public bool Monkey = false;
    [System.NonSerialized] public bool Pheasant = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Dog : " + Dog);
    }
}
