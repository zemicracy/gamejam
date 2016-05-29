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
        var _score = GameObject.Find("Score").transform.FindChild("Text").GetComponent<Score>();
        _score.AddScore(20);

        Destroy(this.gameObject);
    }
}
