using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[DefaultExecutionOrder(20000)]
public class MainUIManager : MonoBehaviour
{
    private GameObject mainManager;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI ammoCountText;
    public GameObject gameOverText;

    // Start is called before the first frame update
    void Awake()
    {
        mainManager = GameObject.Find("MainManager");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + GameManager.Instance.score;
        ammoCountText.text = "AMMO: " + mainManager.GetComponent<MainManager>().ammo;
    }
}
