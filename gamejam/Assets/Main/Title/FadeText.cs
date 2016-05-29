using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeText : MonoBehaviour {
    [SerializeField]
    private GameObject fadeobj;
    Fade fade;
    bool flg;
    float alpha;
    
    
	// Use this for initialization
	void Start () {
        flg = true;
        fade = fadeobj.GetComponent<Fade>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            fade.FadeStart();
        }

        transform.GetComponent<Text>().color = new Color(1, 1, 1, alpha);
        if (flg)
        {
            alpha -= Time.deltaTime;
            if(alpha < 0)
            {
                flg = !flg;
            }
        }
        else
        {
            alpha += Time.deltaTime;
            if (alpha > 1)
            {
                flg = !flg;
            }

        }
    }
}
