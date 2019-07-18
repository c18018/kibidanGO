using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZairyouController : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;

        Vector3 pos = myTransform.position;
        if (pos.x >= 0 && pos.y >= 0)
        {
            pos.x += 0f;
            pos.y += 0f;

        }
        else
        {
            pos.x += 0.05f;
            pos.y += 0.025f;
        }
        myTransform.position = pos;

    }
}
