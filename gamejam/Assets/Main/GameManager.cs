using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameManager : MonoBehaviour {

    [SerializeField]
    TimeManager m_telopTime;
    [SerializeField]
    Telop m_telop;
    [SerializeField]
    DisasterManager m_disaster;
    [SerializeField]
    Score m_score;

    bool m_isDisasterStart = false;
    bool m_isSet = false;
    Dictionary<int, DisasterManager.DisasterType> m_disasterTypeHash = new Dictionary<int, DisasterManager.DisasterType>(){
        {0,DisasterManager.DisasterType.eEarthquake},
         {1,DisasterManager.DisasterType.eEruption},
          {2,DisasterManager.DisasterType.eFlood},
         {3,DisasterManager.DisasterType.eThunder},
         {4,DisasterManager.DisasterType.eTyphoon},
    };

    Dictionary<DisasterManager.DisasterType,int> m_disasterTimeHash = new Dictionary<DisasterManager.DisasterType,int>(){
        {DisasterManager.DisasterType.eEarthquake,5},
         {DisasterManager.DisasterType.eEruption,5},
          {DisasterManager.DisasterType.eFlood,15},
         {DisasterManager.DisasterType.eThunder,5},
         {DisasterManager.DisasterType.eTyphoon,10},
    };
    DisasterManager.DisasterType m_nextType;
    float m_timeCount;
    float m_time;

    float m_disasterTimeCount = 0.0f;
    float m_disasterTime = 0.0f;

    [SerializeField]
    int StartRangeMax;
    [SerializeField]
    int StartRangeMin;

    enum eState
    {
        eNull,
        eRun,
        eEnd
    }

    eState m_state;
    void Awake()
    {
        m_disasterTime = UnityEngine.Random.Range(StartRangeMin, StartRangeMax);
        m_state = eState.eRun;
    }

	// Update is called once per frame
	void Update () {
        
        mRun();

        mEnd();
       
	}


    // タイプ取得用
    DisasterManager.DisasterType mGetDisaster(int number)
    {
        return m_disasterTypeHash[number];
    }

    string mGetDisaterTypeToString(DisasterManager.DisasterType type){
        switch (type)
        {
         case DisasterManager.DisasterType.eEarthquake:
                return "地震";
         case DisasterManager.DisasterType.eFlood:
                return "洪水";
         case DisasterManager.DisasterType.eThunder:
                return "雷";
         case DisasterManager.DisasterType.eTyphoon:
                return "台風";
         case DisasterManager.DisasterType.eEruption:
                return "噴火";
        }
        return "エラー";
    }

    void mRun()
    {
        if (m_state != eState.eRun) return;
        if (!m_isSet && m_disaster.mIsEnd())
        {
            m_disasterTimeCount += Time.deltaTime;
        }

        //
        if (!m_isDisasterStart && !m_isSet && m_disasterTimeCount > m_disasterTime && m_disaster.mIsEnd())
        {
            m_time = m_telopTime.mGetRandam();

            int randam = UnityEngine.Random.Range(0, 4);

            m_nextType = mGetDisaster(randam);

            m_telop.mSetProperty(mGetDisaterTypeToString(m_nextType), m_time.ToString());
            m_telop.mAccident();
            m_isDisasterStart = true;
        }

        //
        if (m_telop.IsEnd && m_isDisasterStart)
        {
            m_timeCount += Time.deltaTime;
        }

        //
        if (!m_isSet && m_timeCount > (m_time / 2))
        {
            m_disaster.mNextSet(m_nextType, m_disasterTimeHash[m_nextType]);
            m_isSet = true;
        }

        //
        if (m_isDisasterStart && m_timeCount > m_time )
        {
            m_disaster.mNextStart();
            m_timeCount = 0;
            m_isDisasterStart = false;
            m_isSet = false;
            m_disasterTimeCount = 0.0f;
            m_disasterTime = UnityEngine.Random.Range(StartRangeMin, StartRangeMax);

        }
    }
    /*
     終了処理
     * ランキングの保存とかはここでやろうか
     */
    void mEnd()
    {

    }
}
