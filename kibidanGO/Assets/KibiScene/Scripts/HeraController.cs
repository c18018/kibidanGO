using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("False", 0);

        Invoke("Cancel", 3);

        Invoke("True", 4);
    }

    void False()
    {
        gameObject.SetActive(false);
    }

    void Cancel()
    {
        CancelInvoke("Call");
    }

    void True()
    {
        gameObject.SetActive(true);
    }

    public void OnClick()
    {
        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;
        pos.x -= 0.1f;    // x座標へ0.01加算

        myTransform.position = pos;
    }

}
