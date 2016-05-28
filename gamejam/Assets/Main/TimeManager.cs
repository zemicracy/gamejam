using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    [SerializeField]
    int RandamMax;
    [SerializeField]
    int RandamMin;

    bool m_isStart = false;

   private int m_time = 0;

    public int mTime
    {
        get { return m_time; }
    }

    public bool IsStart
    {
        get { return m_isStart; }
        set { m_isStart = value; }
    }

    // ランダム値の取得
    public int mGetRandam()
    {
        m_time = UnityEngine.Random.Range(RandamMin, RandamMax);
        return m_time;
    }
}
