using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }  //ENCAPSULATION

    public int score;

    public int highScore;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        LoadData();
}

    // Update is called once per frame
    void Update()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }

    private class SaveInfo
    {
        public int highscore;
    }

    public void SaveData()
    {
        SaveInfo data = new SaveInfo();

        data.highscore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveInfo data = JsonUtility.FromJson<SaveInfo>(json);

            highScore = data.highscore;
        }
    }
}
