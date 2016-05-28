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
    bool m_isDisasterStart = false;
    bool m_isSet = false;
    Dictionary<int, DisasterManager.DisasterType> m_disasterTypeHash = new Dictionary<int, DisasterManager.DisasterType>(){
        {0,DisasterManager.DisasterType.eEarthquake},
         {1,DisasterManager.DisasterType.eEruption},
          {2,DisasterManager.DisasterType.eFlood},
         {3,DisasterManager.DisasterType.eThunder},
         {4,DisasterManager.DisasterType.eTyphoon},
    };

    DisasterManager.DisasterType m_nextType;
    float m_timeCount;
    float m_time;

	
	// Update is called once per frame
	void Update () {

        //
        if (!m_isDisasterStart&&!m_isSet&&Input.GetKeyDown(KeyCode.Space))
        {
            m_time = m_telopTime.mGetRandam();

            int randam = UnityEngine.Random.Range(0, 4);

            m_nextType = mGetDisaster(0);

            m_telop.mSetProperty(mGetDisaterTypeToString(m_nextType), m_time.ToString());
            m_isDisasterStart = true;
        }

        //
        if (m_telop.IsEnd && m_isDisasterStart)
        {
            m_timeCount += Time.deltaTime;   
        }

        //
        if (!m_isSet&&m_timeCount > (m_time / 2))
        {
            m_disaster.mNextSet(m_nextType);
            m_isSet = true;
        }

        //
        if (m_isDisasterStart && m_timeCount > m_time)
        {
            m_disaster.mNextStart();
            m_timeCount = 0;
            m_isDisasterStart = false;
            m_isSet = false;
        }
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
                return "火山";
        }
        return "エラー";
    }
}
