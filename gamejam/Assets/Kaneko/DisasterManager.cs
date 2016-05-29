using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisasterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_field;
    [SerializeField]
    private GameObject m_fxLayer;
    [SerializeField]
    private GameObject m_player;

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioClip audioClip4;
    public AudioClip audioClip5;
    private AudioSource audioSource;


    public enum DisasterType
    {
        eThunder,   //雷
        eFlood,     //洪水
        eEarthquake,//地震
        eEruption,  //噴火
        eTyphoon,   //台風
        eNull
    }
    DisasterType m_type;

    public enum DisasterState
    {
        eInit, ePrePlay, ePlay, eFin
    }
    DisasterState m_state;
    Vector3 m_stageOrigin;
    bool m_isEnd;
    bool m_animFlg;
    bool m_isPlayed;

    //test
    Text m_text;

    float m_animTime = 10;

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        m_type = DisasterType.eNull;
        m_isEnd = true;
        m_isPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            mNextSet(DisasterType.eTyphoon,20);
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
        switch (m_type)
        {
            case DisasterType.eThunder:
                break;
            case DisasterType.eFlood:
                m_stageOrigin = m_fxLayer.transform.FindChild("Flood").FindChild("Water").transform.position;
                break;
            case DisasterType.eEarthquake:
                m_stageOrigin = m_field.transform.position;
                break;
            case DisasterType.eEruption:
                break;
            case DisasterType.eTyphoon:
                m_stageOrigin = m_fxLayer.transform.FindChild("Typhoon").FindChild("tornado").transform.position;
                break;
            case DisasterType.eNull:
                break;
            default:
                break;
        }
        m_state = DisasterState.ePrePlay;
    }
    float fade = 0;
    void mStatePrePlay()
    {
        switch (m_type)
        {
            case DisasterType.eThunder:
                {
                    audioSource.clip = audioClip1;
                    audioSource.Play();

                    var obj = m_fxLayer.transform.FindChild("Thunder").FindChild("onScreen");
                    obj.transform.gameObject.SetActive(true);
                    var color = obj.GetComponent<SpriteRenderer>().color;
                    obj.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, fade);
                    if (fade >= 0.5)
                    {
                        fade = 0.5f;
                    }
                    else
                    {
                        fade += Time.deltaTime * Time.timeScale;
                    }
                }
                break;
            case DisasterType.eFlood:
                {
                    audioSource.clip = audioClip2;
                    audioSource.Play();
                    var obj = m_fxLayer.transform.FindChild("Flood").FindChild("flood");
                    obj.gameObject.SetActive(true);
                    obj.transform.GetComponent<ParticleSystem>().Play();
                   

                }
                break;
            case DisasterType.eEarthquake:
                 audioSource.clip = audioClip3;
                    audioSource.Play();
                float rad = Random.Range(0, 360);
                m_field.transform.position = new Vector3(Mathf.Sin(rad * 180 / Mathf.PI)*0.02f, Mathf.Cos(rad * 180 / Mathf.PI) * 0.02f, 0)
                    + m_stageOrigin;
                break;
            case DisasterType.eEruption:
                {
                    audioSource.clip = audioClip4;
                    audioSource.Play();
                    var obj = m_fxLayer.transform.FindChild("Eruption").FindChild("onScreen");
                    obj.transform.gameObject.SetActive(true);
                    var color = obj.GetComponent<SpriteRenderer>().color;
                    obj.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, fade);
                    if (fade >= 0.5)
                    {
                        fade = 0.5f;
                    }
                    else
                    {
                        fade += Time.deltaTime * Time.timeScale;
                    }
                }
                break;
            case DisasterType.eTyphoon:
                {
                    audioSource.clip = audioClip5;
                    audioSource.Play();
                    var obj = m_fxLayer.transform.FindChild("Typhoon");
                    obj.FindChild("onScreen").gameObject.SetActive(true);
                    var color = obj.FindChild("onScreen").GetComponent<SpriteRenderer>().color;
                    obj.FindChild("onScreen").GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, fade);
                    if (fade >= 0.5)
                    {
                        fade = 0.5f;
                    }
                    else
                    {
                        fade += Time.deltaTime * Time.timeScale;
                    }
                    obj.FindChild("rain").transform.gameObject.SetActive(true);
                    obj.FindChild("rain").GetComponent<ParticleSystem>().Play();
                }
                break;
            case DisasterType.eNull:
                break;
            default:
                break;
        }

    }

    void mStatePlay()
    {
        m_isPlayed = true;
        switch (m_type)
        {
            case DisasterType.eThunder:
                {
                    var obj = m_fxLayer.transform.FindChild("Thunder").FindChild("thunder");
                    obj.gameObject.SetActive(true);

                    obj.position = m_player.transform.position;
                    obj.Translate(new Vector3(0, 30, 0));
                }
                break;
            case DisasterType.eFlood:
                {
                    var obj = m_fxLayer.transform.FindChild("Flood").FindChild("Water");
                    obj.transform.gameObject.SetActive(true);
                 
                    float faze = -1;
                    if (obj.transform.position.x < 5 && !m_animFlg)
                    {
                        m_animFlg = true;
                    }
                    if (m_animFlg)
                    {
                        faze = 1;
                    }
                    obj.transform.Translate(new Vector3(4 * Time.deltaTime * faze, 0, 0));
                    Debug.Log(obj.transform.position.x + "    " + (-m_stageOrigin.x));
                    if (obj.transform.position.x > m_stageOrigin.x)
                    {
                        m_animTime = -1;
                    }
                }
                break;
            case DisasterType.eEarthquake:
                float rad = Random.Range(0, 360);
                float power = m_animTime / 2 < 1.0f ? m_animTime / 10: 1;
                m_field.transform.position = new Vector3(Mathf.Sin(rad * 180 / Mathf.PI) * 0.2f * power, Mathf.Cos(rad * 180 / Mathf.PI) * 0.2f * power, 0)
                    + m_stageOrigin;

                break;
            case DisasterType.eEruption:
                {
                    var obj = m_fxLayer.transform.FindChild("Eruption").FindChild("volcano");
                    obj.transform.gameObject.SetActive(true);
                    var particleSystem = obj.GetComponent<ParticleSystem>();
                    if (!particleSystem.isStopped && !particleSystem.isPlaying)
                    {
                        obj.GetComponent<ParticleSystem>().Play();
                    }
                    else if(particleSystem.isStopped)
                    {
                        m_animTime = -1;
                    }
                }
                break;
            case DisasterType.eTyphoon:
                {
                    var obj = m_fxLayer.transform.FindChild("Typhoon").FindChild("tornado");
                    obj.transform.gameObject.SetActive(true);
                    obj.GetComponent<ParticleSystem>().Play();
                    obj.transform.Translate(new Vector3(-4 * Time.deltaTime, 0, 0));
                    Debug.Log(obj.transform.position.x + "    " + (-m_stageOrigin.x));
                    if(obj.transform.position.x < -m_stageOrigin.x)
                    {
                        m_animTime = -1;
                    }
                }
                break;

            case DisasterType.eNull:
                break;
            default:
                break;
        }
        if (m_animTime < 0)
        {
            m_state = DisasterState.eFin;
        }
        else
        {
            m_animTime -= Time.deltaTime * Time.timeScale;
        }
    }
    void mStateFinalize()
    {
        switch (m_type)
        {
            case DisasterType.eThunder:
                {
                    audioSource.Stop();
                    var obj = m_fxLayer.transform.FindChild("Thunder").FindChild("onScreen");
                    obj.transform.gameObject.SetActive(false);
                    m_fxLayer.transform.FindChild("Thunder").FindChild("thunder").transform.gameObject.SetActive(false);
                    fade = 0;
                    m_type = DisasterType.eNull;
                    m_state = DisasterState.eFin;
                    m_isEnd = true;
                }
                break;
            case DisasterType.eFlood:
                {
                    audioSource.Stop();

                    var obj = m_fxLayer.transform.FindChild("Flood");
                    obj.FindChild("flood").gameObject.SetActive(false);
                    obj.FindChild("Water").gameObject.SetActive(false);

                    m_type = DisasterType.eNull;
                    m_state = DisasterState.eFin;
                    m_isEnd = true;
                }
                break;
            case DisasterType.eEarthquake:
                audioSource.Stop();
                m_field.transform.position = m_stageOrigin;
                m_type = DisasterType.eNull;
                m_state = DisasterState.eFin;
                m_isEnd = true;
                break;
            case DisasterType.eEruption:
                {
                    var obj = m_fxLayer.transform.FindChild("Eruption").FindChild("onScreen");
                    obj.transform.gameObject.SetActive(false);
                    m_fxLayer.transform.FindChild("Thunder").FindChild("volcano").transform.gameObject.SetActive(false);
                    fade = 0;
                    m_type = DisasterType.eNull;
                    m_state = DisasterState.eFin;
                    audioSource.Stop();
                    m_isEnd = true;
                }
                break;
            case DisasterType.eTyphoon:
                {
                    audioSource.Stop();
                    var obj = m_fxLayer.transform.FindChild("Typhoon");
                    obj.FindChild("rain").gameObject.SetActive(false);
                    obj.FindChild("tornado").gameObject.SetActive(false);
                    obj.FindChild("tornado").transform.position = m_stageOrigin;
                    var color = obj.FindChild("onScreen").GetComponent<SpriteRenderer>().color;
                    obj.FindChild("onScreen").GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, fade);
                    if (fade <= 0)
                    {
                        fade = 0.0f;
                        obj.FindChild("onScreen").gameObject.SetActive(false);
                        m_type = DisasterType.eNull;
                        m_state = DisasterState.eFin;
                        m_isEnd = true;

                    }
                    else
                    {
                        fade -= Time.deltaTime * Time.timeScale;
                    }
                }
                break;

            case DisasterType.eNull:
                break;
            default:
                break;
        }
        m_isPlayed = false;

    }


    public void mNextSet(DisasterType type,float animateTime)
    {
        if (!m_isEnd) return;
        m_type = type;
        m_state = DisasterState.eInit;
        m_animTime = animateTime;
        m_isEnd = false;
    }

    public void mNextStart()
    {
        m_state = DisasterState.ePlay;
    }

    public bool mIsEnd()
    {
        return m_isEnd;
    }
    
    public DisasterType mGetType()
    {
        return m_type;
    }

    public bool mIsPlay()
    {
        return m_isPlayed;
    }




}
