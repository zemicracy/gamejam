using UnityEngine;
using System.Collections;

public class Flame : MonoBehaviour {

    [SerializeField]
    private Telop Telop;
	
	// Update is called once per frame
	void Update () {
        if (Telop.IsEnd)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.0f);
       
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.3f);
       
        }
	}
}
