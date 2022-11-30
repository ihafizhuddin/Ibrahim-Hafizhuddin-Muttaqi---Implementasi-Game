using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour{
    public static GameManager get;
    [Header("Other Manager")]
    [SerializeField] UIManager ui;
    [SerializeField] JsonManager json;

    [Header("game stats")]
    public bool isPlaying = false;

    [Header("player stats")]
    public int health = 5; 
    public string nama = "";
    public int score = 0;
    public float cooldownSpawner = 5f;
    public CharaSO characterChosen;
    public Player player;
    public HighScoreData hsData;

    public void Awake(){
        if(get == null){
            get = this;
        }
        if(get!= null && get != this){
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start(){
        Time.timeScale = 0;
        GetHighScoreFromJson();

        // health = characterChosen.nyawa;
    }

    // Update is called once per frame
    // void Update(){
        
    // }
    public void ChooseChara(CharaSO value){
        characterChosen = value;
        health = value.nyawa;
        nama = value.nama;
        player.speed = value.speed;
        player.SetPlayer(value);
        StartGame();
    }
    public float SetCoolDown(int value){
        if(value < 1000){
            cooldownSpawner = 5f;
        }else if( value < 5000){
            cooldownSpawner = 4f;
        }else if( value < 12000){
            cooldownSpawner = 3f;
        }else{
            cooldownSpawner = 1.5f;
        }
        return cooldownSpawner;
    }
    public void AddScore(int value){
        score+= value;
        SetCoolDown(score);
        ui.UpdateScore();

    }
    public void MinHealth(){
        health--;
        ui.UpdateHealth();
        if(health <= 0){
            GameOver();
        }
    }
    public void StartGame(){
        Time.timeScale = 1;
        ui.UpdateHealth();
        ui.UpdateScore();
        isPlaying = true;
        Vector3 startPos = player.transform.position;
        startPos.x = 0;
        player.transform.position = startPos;
        GetHighScoreFromJson();
    }
    public void GameOver(){
        Time.timeScale = 0;
        isPlaying = false;
        Debug.Log("GameOver");
        if(hsData.score < score){
            ui.ShowNewHighScore();
        }
        ui.GameOver();
    }
    public void Restart(){
        Spawner.ins.CleanPool();
        ui.ShowStartGame();
        score = 0;
        ui.UpdateScore();
    }
    public void PauseGame(){
        if(!isPlaying)return;
        isPlaying = false;
        Time.timeScale = 0;
        ui.Pause();
    }
    public void ResumeGame(){
        isPlaying = true;
        Time.timeScale = 1;
        ui.Resume();
    }
    public HighScoreData GetHighScoreFromJson(){
        hsData = json.LoadHighScoreData();
        return hsData;
    }
    public void SaveHighScoreDataToJson(){
        string nama = ui.hsInputTMP.text;
        int highscore = score;
        json.SaveHighScoreData(nama,highscore);
        GetHighScoreFromJson();
        ui.GameOver();
    }
}
