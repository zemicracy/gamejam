using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {


    [SerializeField]
    int ScorePoint;

    [SerializeField]
    Sprite Object;

    [SerializeField]
    Score score;
    void Awake()
    {
        this.transform.parent = GameObject.Find("ItemManager").transform;
    }
    void OnTriggerEnter2D(Collider2D colision)
    {
        Debug.Log("ゲット");
        Destroy(this.gameObject);
    }
}
