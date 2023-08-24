using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    private GameObject firePoint;

    private Vector3 offset = new Vector3(0f, 5.141f, -9.158f);
    
    // Start is called before the first frame update
    void Awake()
    {
        firePoint = GameObject.Find("FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ballPrefab, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}
