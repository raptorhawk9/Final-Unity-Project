using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private GameObject[] targetPrefabs;

    // Start is called before the first frame update
    void Awake()
    {
        InvokeRepeating("spawnRandomTarget", 5, 1f);
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
        return new Vector3(Random.Range(-170f, 170f), Random.Range(-700f, 700f), targetZ);
    }
}
