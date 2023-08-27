using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[DefaultExecutionOrder(20000)]
public class MainUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + GameManager.Instance.score;
    }
}
