using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(2000)]
public class MenuUIFunctions: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Awake()
    {
        highScoreText.SetText("HIGHSCORE: " + GameManager.Instance.highScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        GameManager.Instance.SaveData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
