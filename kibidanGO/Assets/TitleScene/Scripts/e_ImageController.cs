using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class e_ImageController : MonoBehaviour
{
    Image momo, dog, mon, phe;
    float m_red, d_red, s_red, p_red;
    float m_green, d_green, s_green, p_green;
    float m_blue, d_blue, s_blue, p_blue;
    float m_alfa, d_alfa, s_alfa, p_alfa;

    // Start is called before the first frame update
    void Start()
    {
        momo = GameObject.FindGameObjectWithTag("Cloud1").GetComponent<Image>();
        dog = GameObject.FindGameObjectWithTag("Dog").GetComponent<Image>();
        mon = GameObject.FindGameObjectWithTag("Monkey").GetComponent<Image>();
        phe = GameObject.FindGameObjectWithTag("Pheasant").GetComponent<Image>();

        m_red = momo.color.r;
        m_green = momo.color.g;
        m_blue = momo.color.b;
        m_alfa = momo.color.a;

        d_red = dog.color.r;
        d_green = dog.color.g;
        d_blue = dog.color.b;
        d_alfa = dog.color.a;

        s_red = mon.color.r;
        s_green = mon.color.g;
        s_blue = mon.color.b;
        s_alfa = mon.color.a;

        p_red = phe.color.r;
        p_green = phe.color.g;
        p_blue = phe.color.b;
        p_alfa = phe.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        MomoMove();
    }

    void MomoMove()
    {
        //float x = momo.transform.position.x;
        //float y = momo.rectTransform.position.y;

        //Debug.Log(x + "  " + y);
        
        momo.color = new Color(m_red, m_green, m_blue, m_alfa);
        m_alfa += 0.01f;

        dog.color = new Color(d_red, d_green, d_blue, d_alfa);
        d_alfa += 0.01f;

        mon.color = new Color(s_red, s_green, s_blue, s_alfa);
        s_alfa += 0.01f;

        phe.color = new Color(p_red, p_green, p_blue, p_alfa);
        p_alfa += 0.01f;

        /*if(x <= -454 || y <= -206)
        {
            momo.rectTransform.Translate(-2, -1, 0);
        }*/

        if (m_alfa >= 2.0f)
        {
            m_alfa = 1.5f;
            d_alfa = 1.5f;
            s_alfa = 1.5f;
            p_alfa = 1.5f;
        }
    }

}
