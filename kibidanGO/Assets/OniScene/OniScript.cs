using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OniScript : MonoBehaviour
{
    private int m_oniHP = 500;
    public int OniHP
    {
        get { return this.m_oniHP; }
        set { this.m_oniHP = value; }
    }

    private int m_attackRandom = 0;

    private bool m_oniupper;
    private bool m_onimiddle;
    private bool m_onilower;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("OniAttackRandom");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_attackRandom);
    }

    IEnumerator OniAttackRandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            m_attackRandom = Random.Range(1, 4);

            if (m_attackRandom == 1)
                m_oniupper = true;
            else if (m_attackRandom == 2)
                m_onimiddle = true;
            else if (m_attackRandom == 3)
                m_onilower = true;
        }
    }

}
