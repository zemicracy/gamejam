using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    private int score = 0;
    private int[] Ranking_Score = {0,0,0};
    private bool is_Render=false;

    private float timeleft;

    readonly string[] High_Score_Key = { "highScore", "highScore1" };

    public void AddScore(int a)
    {
        score += a;
    }

    // const string High_Score_Key = "highscore";

    // Use this for initialization
    void Start()
    {
        scoreText.text = "Score:0";
        is_Render = false;
        Ranking_Score[0] = PlayerPrefs.GetInt("highScore");
    }

  
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.C))
        {
            is_Render = true;
        }

        if (is_Render == true)
        {
            Paint();
            is_Render=false;
        }

        HighScoreUpdate();
        timeleft -= Time.deltaTime;
        if (timeleft <= -2.0)
        {
            timeleft = 0.0f;
            score += 10;
        }
            scoreText.text = "Score:" + score.ToString();
	}

   void  Paint(){
        scoreText.text = "Score:" + Ranking_Score[0].ToString();
    }

    void HighScoreUpdate()
    {
       
        //ハイスコア更新

        if (score > Ranking_Score[0])
        {
            Ranking_Score[0] = score;
            PlayerPrefs.SetInt("highScore", Ranking_Score[0]);
          
        }
    }
}
