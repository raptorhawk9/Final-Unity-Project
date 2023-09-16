using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIFunctions: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    private void Start()
    {
        LoadData();
    }

    void Awake()
    {
        highScoreText.SetText("HIGHSCORE: " + GameManager.Instance.highScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private class SaveInfo
    {
        public int highscore;
    }

    private void SaveData()
    {
        SaveInfo data = new SaveInfo();

        data.highscore = GameManager.Instance.highScore;

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadData()
    {
        SaveInfo data = new SaveInfo();

        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            data = JsonUtility.FromJson<SaveInfo>(json);

            GameManager.Instance.highScore = data.highscore;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        SaveData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
