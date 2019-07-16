using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class h_CheckInstance : MonoBehaviour
{
    public static h_CheckInstance instance = null;

    public static h_CheckInstance Instance
    {
        get { return h_CheckInstance.instance; }
    }

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

    }
}
