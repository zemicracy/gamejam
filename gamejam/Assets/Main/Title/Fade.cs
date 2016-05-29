using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    float a;
    bool flg;

    [SerializeField]
    GameObject fadeImage;
    SpriteRenderer sprite;

    string next;
    // Use this for initialization
    void Start()
    {
        sprite = fadeImage.GetComponent<SpriteRenderer>();
        flg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (flg)
        {
            a += Time.deltaTime;
            sprite.color = new Color(0, 0, 0, a);
            if (a > 1)
            {
                flg = false;
                Application.LoadLevel(next);
            }
        }

     }

    float m_alpha = 0f;

    public void FadeStart(string name)
    {
        next = name;
        flg = true;
    }
}