using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MixController : MonoBehaviour
{

    private int counter = 0;
    const int counterMax = 6;

    public GameObject Hera;
    private float speed;
    public bool move = false;

    private float timer = 0;
    public int interval = 1;
    public bool button = true;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("False", 0);

        Invoke("Cancel", 3);

        Invoke("True", 4);

        speed = 6.0f;
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

    private void Update()
    {
        if (move)
        {
            Hera.transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, speed);
            timer += Time.deltaTime;
            if (timer > interval)
            {
                timer = 0;
                counter++;
                move = false;
            }
        }
    }
    // Update is called once per frame
    public void OnClick()
    {
        Debug.Log("clicked");
        move = true;
        if (counter >= counterMax)
        {
            Debug.Log("完成！");
            gameObject.SetActive(false);
            SceneManager.LoadScene("Kibi_Finish");
        }
        Invoke("false", 0);

        Invoke("cancel", 3);

        Invoke("true", 3);
    }

}
