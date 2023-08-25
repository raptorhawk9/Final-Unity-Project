using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    private GameObject firePoint;

    private Vector3 offset = new Vector3(0f, 5.141f, -9.158f);

    private float fireCountDown = 2;
    
    // Start is called before the first frame update
    void Awake()
    {
        firePoint = GameObject.Find("FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        CheckFire();
    }

    private void Fire()
    {
        Instantiate(ballPrefab, firePoint.transform.position, firePoint.transform.rotation);
    }

    private void CheckFire()
    {
        fireCountDown += Time.deltaTime;

        if (fireCountDown >= 2 && Input.GetKeyDown(KeyCode.Space))
        {
            Fire();

            fireCountDown = 0;
        }
    }
}
