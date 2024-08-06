using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    static public DataManager Instance { get; private set; }
    public string playerNameBest;
    public string playerNameCurrent;
    public int score;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadDataGame();
    }
    private void Start()
    {
      
    }
    public void SavePlayerNameCurrent(string playerName)
    {
        this.playerNameCurrent = playerName;

    }
    public void SaveDataGame(int score)
    {
        this.playerNameBest = playerNameCurrent;
        this.score = score;
        SaveData data = new SaveData(); 
        data.playerNameBest = playerNameBest;
        data.score = score;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/data.json", json);

    }
    public void LoadDataGame()
    {
        string path = Application.persistentDataPath + "/data.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            this.score = data.score;
            this.playerNameBest = data.playerNameBest;
        }
        else
        {
            Debug.Log("Load failed");
        }
    }
    class SaveData
    {
        public int score;
        public string playerNameBest;
    }
}
