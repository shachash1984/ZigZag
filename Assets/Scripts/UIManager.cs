using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager UIinstance;
    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScore;

	
    void Awake()
    {
        if(UIinstance == null)
        {
            UIinstance = this;
        }
    }

	void Start () {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    } 
	
	
	void Update () {
		
	}

    public void GameStart()
    {
        tapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore.text = "High Score: " + PlayerPrefs.GetInt("highScore");



    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
