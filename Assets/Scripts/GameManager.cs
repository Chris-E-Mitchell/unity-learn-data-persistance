using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string PlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class HighScoreData
    {
        public string Name;
        public int Score;
    }

    public void SaveHighScore(int score)
    {
        HighScoreData highScoreData = new HighScoreData();
        highScoreData.Name = PlayerName;
        highScoreData.Score = score;

        string json = JsonUtility.ToJson(highScoreData);

        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public HighScoreData LoadHighScore()
    {
        HighScoreData highScoreData = new HighScoreData();

        string path = Application.persistentDataPath + "/highscore.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            highScoreData = JsonUtility.FromJson<HighScoreData>(json);
        }
        else
        {
            highScoreData.Name = "";
            highScoreData.Score = 0;
        }

        return highScoreData;
    }
}
