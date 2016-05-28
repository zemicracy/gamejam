using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Telop : MonoBehaviour {

    private float m_time = 0.0f;
    private bool m_flashFlg = false;
    private int m_stringChanger = 0;
    private bool m_telopStart = false;

    [SerializeField]
    private float WaitTime;
    [SerializeField]
    private int StringChanger;

    private bool m_isEnd = false;

    public bool IsEnd
    {
        get
        {
            return m_isEnd;
        }
    }

    public void mSetProperty(){
        m_isEnd = false;
        m_flashFlg = false;
        m_telopStart = false;
    }

	// Update is called once per frame
	void Update () {

        if (m_isEnd) return;
        mFlashing(m_flashFlg);

        if (m_telopStart)
        {
            this.GetComponent<Text>().transform.Translate(new Vector3(-0.5f, 0, 0));

            Debug.Log(this.GetComponent<Text>().transform.position.x);
            if (this.GetComponent<Text>().transform.position.x < -300)
            {
                m_isEnd = true;
            }
        }
       
       
        if (mUpdateTime())
        {
            if (m_telopStart) return;

            m_stringChanger += 1;

            if (m_stringChanger > StringChanger)
            {
                m_flashFlg = true;
                m_telopStart = true;
                this.GetComponent<Text>().text = "あと"+"10"+"秒後に"+"地震"+"が来ます。"+"丘の上"+"に避難してください。";
                this.GetComponent<Text>().transform.Translate(new Vector3(100, 0, 0));
                
            }
            else
            {
                m_flashFlg = !m_flashFlg;
                this.GetComponent<Text>().text = "緊急速報";
            }
        }

	}

    bool mUpdateTime()
    {
        // 時間の加算
        m_time += Time.deltaTime;

        if (m_time < WaitTime) return false;
        m_time = 0.0f;

        return true;

    }

    // 点滅
    void mFlashing(bool flg)
    {
        if (m_flashFlg)
        {
            this.GetComponent<Text>().color = new Color(255.0f, 255.0f, 255.0f, 1.0f);
        }
        else
        {
            this.GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
