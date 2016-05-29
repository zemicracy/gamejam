using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

    private bool m_isEnd = true;
    string m_disater;
    string m_timeCount;
    Vector3 initPosition;
    Dictionary<string, string> m_evacuation = new Dictionary<string, string>(){
        { "地震", "広場" },
        { "洪水", "高いところ" },
        { "雷", "避雷針" },
        {"台風","洞窟"},
        {"噴火","洞窟"}
    };

    enum eState
    {
        eTime,
        eType,
        eNull
    }
    eState m_state = eState.eType;
    bool m_accident = false;
    public bool IsEnd
    {
        get
        {
            return m_isEnd;
        }
    }
    void Awake()
    {
        initPosition = this.GetComponent<Text>().transform.position;
    }
    public void mSetProperty(string disater,string timeCount){
        m_isEnd = false;
        m_flashFlg = false;
        m_telopStart = false;
        m_accident = false;
        m_stringChanger = 0;
        m_time = 0.0f;
        m_disater = disater;
        m_timeCount = timeCount;
        this.GetComponent<Text>().transform.position = initPosition;
    }

	// Update is called once per frame
	void Update () {

        if (m_isEnd)
        {
            mFlashing(false);
            return;
        }

        mFlashing(m_flashFlg);

        if (m_telopStart)
        {
            this.GetComponent<Text>().transform.Translate(new Vector3(-0.5f, 0, 0));

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
                if (m_accident)
                {
                    if (m_state == eState.eType)
                    {
                        this.GetComponent<Text>().text = "あと" + m_timeCount + "秒後に" + "???が来ます。???に避難してください。";
                    }
                    else if (m_state == eState.eTime)
                    {
                        this.GetComponent<Text>().text = "あと" + "??秒後に" + m_disater + "が来ます。" + m_evacuation[m_disater] + "に避難してください。";
                    }
                }
                else
                {
                    this.GetComponent<Text>().text = "あと" + m_timeCount + "秒後に" + m_disater + "が来ます。" + m_evacuation[m_disater] + "に避難してください。";
                }
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

    //
    public void mAccident()
    {
        int randam = UnityEngine.Random.Range(0, 100);
        if (randam < 50)
        {
            m_accident = false;
        }
        else if (randam > 50)
        {
            m_accident = true;
            int randam2 = UnityEngine.Random.Range(0, 100);
            m_state = eState.eType;
           
        }
    
    }
}
