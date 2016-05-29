using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

    [SerializeField]
    private GameObject Item;

    [SerializeField]
    private float RangeMinY;
    [SerializeField]
    private float RangeMaxY;
    [SerializeField]
    private float RangeMinX;
    [SerializeField]
    private float RangeMaxX;

    [SerializeField]
    private int SpownTime;
    [SerializeField]
    private int SpownNum;


    float m_time = 0.0f;
    void Update()
    {
        m_time += Time.deltaTime;
        if (m_time > SpownTime)
        {
            mSetItem(SpownNum);
            m_time = 0.0f;
        }
    }
    void mSetItem(int num)
    {
        for (int i = 0; i < num; ++i)
        {
            GameObject instance = (GameObject)Instantiate(Item);

            float y = UnityEngine.Random.Range(RangeMinY, RangeMaxY);
            float x = UnityEngine.Random.Range(RangeMinX, RangeMaxX);

            instance.transform.position = new Vector3(x, y, 0);

            this.transform.parent = GameObject.Find("Apple(Clone)").transform;
        }
    }
}
