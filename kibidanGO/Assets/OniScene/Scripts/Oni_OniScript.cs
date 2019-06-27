using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni_OniScript : MonoBehaviour
{
    Oni_PlayerScript m_playerScript;

    private int m_oniHP = 500;
    public int OniHP
    {
        get { return this.m_oniHP; }
        set { this.m_oniHP = value; }
    }

    private int m_attackRandom = 0;

    [System.NonSerialized] public bool m_oniupper = false;
    [System.NonSerialized] public bool m_onimiddle = false;
    [System.NonSerialized] public bool m_onilower = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // m_playerScript = GameObject.FindGameObjectWithTag("")
        StartCoroutine("OniAttackRandom");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("上： " + m_oniupper + "中： " + m_onimiddle + "下： " + m_onilower);
    }

    public IEnumerator OniAttackRandom()
    {
        Debug.Log("OniCor Start");
        while (true)
        {
            m_attackRandom = Random.Range(1, 4);
            Debug.Log("Rand " + m_attackRandom);

            if (m_attackRandom == 1)
            {
                m_oniupper = true;
                yield return new WaitForSeconds(3.0f);
            }
            else if (m_attackRandom == 2)
            {
                m_onimiddle = true;
                yield return new WaitForSeconds(3.0f);
            }
            else if (m_attackRandom == 3)
            {
                m_onilower = true;
                yield return new WaitForSeconds(3.0f);
            }
        }
    }
}
