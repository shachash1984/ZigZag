using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager GMInstance;
    public bool gameOver;

    void Awake()
    {
        if(GMInstance == null)
        {
            GMInstance = this;
        }
    }


	void Start () {
        gameOver = false;
        StartGame();
	}
	 
	
	void Update () {
		
	}

    public void StartGame()
    {
        UIManager.UIinstance.GameStart();
        ScoreManager.SMInstance.StartScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
    }

    public void GameOver()
    {
        ScoreManager.SMInstance.StopScore();
        UIManager.UIinstance.GameOver();
        gameOver = true;
    }
}
