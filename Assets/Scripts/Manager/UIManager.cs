using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour{
    [Header("Player HUD")]
    public TMP_Text healthTMP;
    public TMP_Text scoreTMP;

    [Header("GameOver Panel")]
    public GameObject gameoverPanel;
    public TMP_Text scoreGameOverTMP;
    public TMP_Text highscoreGameOverTMP;

    [Header("StartMenu Panel")]
    public GameObject startMenuPanel;
    [Header("Character Choose Panel")]
    public GameObject characterChoosePanel;
    [Header("Pause Panel")]
    public GameObject pausePanel;

    [Header("Highscore Panel")]
    public GameObject highscorePanel;
    public TMP_InputField hsInputTMP;
    public TMP_Text oldHsTMP;
    public TMP_Text newHsTMP;

    public void UpdateHealth(){
        healthTMP.text = "Health : " + GameManager.get.health;
    }

    public void UpdateScore(){
    scoreTMP.text = "Score : " + GameManager.get.score;

    }

    public void GameOver(){
        //Set score text
        scoreGameOverTMP.text = "your score : " + GameManager.get.score;
        if(GameManager.get.hsData.score >= 0){
            HighScoreData highScore = GameManager.get.hsData;
            highscoreGameOverTMP.text = 
            "highscore\n" + 
            highScore.nama + " : " + highScore.score;
        }else{
            highscoreGameOverTMP.text = "";
        }
        //show game over panel
        gameoverPanel.SetActive(true);
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void ShowStartGame(){
        startMenuPanel.SetActive(false);
        characterChoosePanel.SetActive(true);
        gameoverPanel.SetActive(false);
        pausePanel.SetActive(false);
        highscorePanel.SetActive(false);
    }
    public void Pause(){
        pausePanel.SetActive(true);
    }
    public void Resume(){
        pausePanel.SetActive(false);
    }
    public void ShowNewHighScore(){
        int highscore = GameManager.get.score;
        int oldHighscore = GameManager.get.hsData.score;
        oldHsTMP.text = "last highscore : " + oldHighscore;
        newHsTMP.text = "your score : " + highscore;
        highscorePanel.SetActive(true);

    }

    // Start is called before the first frame update
    void Start(){
        startMenuPanel.SetActive(true);
        characterChoosePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        pausePanel.SetActive(false);
        highscorePanel.SetActive(false);
    }

    


    // // Update is called once per frame
    // void Update(){
        
    // }
}
