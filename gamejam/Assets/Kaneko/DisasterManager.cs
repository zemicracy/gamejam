using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisasterManager: MonoBehaviour {
    [SerializeField]
    private GameObject m_field;

    public enum DisasterType
    {
        eThunder,   //雷
        eFlood,     //洪水
        eEarthquake,//地震
        eEruption,  //噴火
        eNull
    }
    DisasterType m_type;

    public enum DisasterState
    {
        eInit,ePrePlay,ePlay,eFin
    }
    DisasterState m_state;
    Vector3 m_stageOrigin;

    //test
    Text m_text;

    float m_animTime = 5;


    // Use this for initialization
    void Start () {
        m_animTime = 10;
        m_type = DisasterType.eNull;
        m_text = transform.FindChild("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            mNextSet(DisasterType.eThunder);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            mNextStart();
        }


        switch (m_state)
        {
            case DisasterState.eInit:
                mStateInit();
                break;
            case DisasterState.ePrePlay:
                mStatePrePlay();
                break;
            case DisasterState.ePlay:
                mStatePlay();
                break;
            case DisasterState.eFin:
                mStateFinalize();
                break;
            default:
                break;
        }

    }
    void mStateInit()
    {
        m_stageOrigin = m_field.transform.position;
        m_state = DisasterState.ePrePlay;
    }
    void mStatePlay()
    {
        switch (m_type)
        {
            case DisasterType.eThunder:
                m_text.text = "Thunder";
                break;
            case DisasterType.eFlood:
                m_text.text = "Flood";
                
                break;
            case DisasterType.eEarthquake:
                float rad = Random.Range(0,360);
                m_field.transform.position = new Vector3(Mathf.Sin(rad * 180 / Mathf.PI)*m_animTime, Mathf.Cos(rad * 180 / Mathf.PI) * m_animTime, 0)
                    + m_stageOrigin;
                m_text.text = "Earthquake";
                break;
            case DisasterType.eEruption:
                m_text.text = "Eruption";
                break;
            case DisasterType.eNull:
                break;
            default:
                break;
        }
        if(m_animTime < 0)
        {
            m_state = DisasterState.eFin;
        }
        else {
            m_animTime -= Time.deltaTime;
        }
    }
    float fade = 0;
    void mStatePrePlay()
    {
        switch (m_type)
        {
            case DisasterType.eThunder:
                m_text.text = "Thunder";
                var obj = m_field.transform.FindChild("Panel");
                obj.transform.gameObject.SetActive(true);
                var color = obj.GetComponent<Image>().color;
                obj.GetComponent<Image>().color = new Color(color.r, color.g, color.b,fade);
                if (fade >= 0.5)
                {
                    fade = 0.5f;
                }else
                {
                    fade += Time.deltaTime;
                }
                break;
            case DisasterType.eFlood:
                m_text.text = "Flood";
                break;
            case DisasterType.eEarthquake:
                m_text.text = "Earthquake";
                break;
            case DisasterType.eEruption:
                m_text.text = "Eruption";
                break;
            case DisasterType.eNull:
                break;
            default:
                break;
        }

    }

    void mStateFinalize()
    {
        switch (m_type)
        {
            case DisasterType.eThunder:
                m_text.text = "NewText";
                var obj = m_field.transform.FindChild("Panel");
                obj.transform.gameObject.SetActive(false);
                fade = 0;
                break;
            case DisasterType.eFlood:
                break;
            case DisasterType.eEarthquake:
                break;
            case DisasterType.eEruption:
                break;
            case DisasterType.eNull:
                break;
            default:
                break;
        }
        m_field.transform.position = m_stageOrigin;
        m_type = DisasterType.eNull;
        m_state = DisasterState.eFin;
    }


    public void mNextSet(DisasterType type)
    {
        m_type = type;
        m_state = DisasterState.eInit;
        m_animTime = 5;
    }

    public void mNextStart()
    {
        m_state = DisasterState.ePlay;
    }

    

    

}
