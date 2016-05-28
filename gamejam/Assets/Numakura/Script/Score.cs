using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    private int score = 0;
    private float timeleft;

	// Use this for initialization
	void Start () {
        scoreText.text = "Score:0";
	}
	
	// Update is called once per frame
	void Update () {

        timeleft -= Time.deltaTime;
        if (timeleft <= -2.0)
        {
            timeleft = 0.0f;
            score += 10;
            scoreText.text = "Score:" + score.ToString();
        }
	}
}
