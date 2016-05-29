using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputScore : MonoBehaviour {

    string [] text = {"Score:","死因:"};
    float time;
	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        Debug.Log(time);
        if (time > 5)
        {
                Input();
        }
	}

    void Input()
    {
            int score = PlayerPrefs.GetInt("highScore");
            Debug.Log(score);
            transform.FindChild("Score").GetComponent<Text>().text = text[0] + score.ToString();
            //string reason = PlayerPrefs.GetInt("highScore");
            //transform.FindChild("reason").GetComponent<Text>().text = text[1] + reason;
    }

    public void Visible()
    {
        gameObject.SetActive(false);
    }

}
