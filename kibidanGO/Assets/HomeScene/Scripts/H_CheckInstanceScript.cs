using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_CheckInstanceScript : MonoBehaviour
{
    public static H_CheckInstanceScript instance = null;

    public static H_CheckInstanceScript Instance
    {
        get { return H_CheckInstanceScript.instance; }
    }

    [System.NonSerialized] public static bool haveDog = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance == this)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("haveDog : " + haveDog);
    }
}
