using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchController : MonoBehaviour
{
    h_Master Master;

    public bool water;
    public bool mochi;
    public bool sugar;
    // Start is called before the first frame update
    void Start()
    {
        Master = GameObject.FindGameObjectWithTag("Master").GetComponent<h_Master>();
        water = Master.water;
        mochi = Master.mochi;
        sugar = Master.sugar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
