using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    private float m_ammo;
    public float ammo
    {
        get
        {
            return m_ammo;
        }

        set
        {
            if (value >= 0)
            {
                m_ammo = value;
            }
            else
            {
                Debug.Log("Negative value, can't do that. ");
            }
        }
    }

    [SerializeField] private GameObject[] targetPrefabs;
    [SerializeField] private GameObject canvas;

    // Start is called before the first frame update
    void Awake()
    {
        InvokeRepeating("spawnRandomTarget", 5, 1f);

        m_ammo = 300;
    }

    private void Update()
    {
        CheckAmmoGone();
    }

    private void CheckAmmoGone()
    {
        if (m_ammo <= 0)
        {
            canvas.GetComponent<MainUIManager>().gameOverText.SetActive(true);

            StartCoroutine(ResetGame());
        }
    }

    private IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(1.5f);

        BackToMenu();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void spawnRandomTarget()
    {
        int randomTargetInt = Random.Range(0, 3);

        GameObject randomTarget = targetPrefabs[randomTargetInt];

        Vector3 spawnPosition = randomSpawnPosition(randomTarget.transform.position.z);

        Instantiate(randomTarget, spawnPosition, randomTarget.transform.rotation);
    }

    private Vector3 randomSpawnPosition(float targetZ)
    {
        return new Vector3(Random.Range(-700f, 700f), Random.Range(-170f, 500f), targetZ);
    }
}
