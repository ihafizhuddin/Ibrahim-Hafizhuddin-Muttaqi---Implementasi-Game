using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonManager : MonoBehaviour{
    public HighScoreData LoadHighScoreData(){
        HighScoreData oldData  = new HighScoreData();
        string path = Application.persistentDataPath + "/highscore.json";
        if(File.Exists(path)){
            var readFileInString = File.ReadAllText(path);
            oldData = JsonUtility.FromJson<HighScoreData>(readFileInString);
        }
        return oldData;
    }
    public void SaveHighScoreData(string nama, int score){
        HighScoreData newData = new HighScoreData();
        newData.nama = nama;
        newData.score = score;
        string path = Application.persistentDataPath + "/highscore.json";
        var json = JsonUtility.ToJson(newData);
        File.WriteAllText(path, json);
    }

}
[System.Serializable]
public class HighScoreData{
    public string nama = "";
    public int score = 0;
}

