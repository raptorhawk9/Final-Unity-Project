using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIFunctions: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
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
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
