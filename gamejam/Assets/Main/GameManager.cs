using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    [SerializeField]
    TimeManager m_timer;
    [SerializeField]
    Telop m_telop;
    [SerializeField]
    DisasterManager m_disaster;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int time = m_timer.mGetRandam();

            m_telop.mSetProperty(mGetDisaterTypeToString(DisasterManager.DisasterType.eEarthquake), time.ToString());
        }
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
