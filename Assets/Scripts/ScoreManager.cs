using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager SMInstance;
    public int score;
    public int highScore;

    void Awake()
    {
        if(SMInstance == null)
        {
            SMInstance = this;
        }
    }

	void Start () {
        
        score = 0;
        PlayerPrefs.SetInt("score", score);
	}
	 
	
	void Update () {
		

	}

    public void IncrementScore()
    {
        score++;
    }

    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }

    public void StopScore()
    {
        CancelInvoke("IncrementScore");

        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if(score > PlayerPrefs.GetInt("highScore"))
            {
                
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else 
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
