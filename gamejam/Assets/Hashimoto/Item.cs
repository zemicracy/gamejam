using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {


    [SerializeField]
    int ScorePoint;

    [SerializeField]
    Sprite Object;

    [SerializeField]
    Score score;
    void OnTriggerEnter2D(Collider2D colision)
    {
        Debug.Log("ゲット");
        Destroy(this.gameObject);
    }
}
