using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    private GameObject firePoint;
    private GameObject cannonBase;
    private GameObject cannon;

    private Vector3 offset = new Vector3(0f, 5.141f, -9.158f);

    private float fireCountDown = 2;
    
    // Start is called before the first frame update
    void Awake()
    {
        firePoint = GameObject.Find("FirePoint");
        cannonBase = GameObject.Find("Base");
        cannon = GameObject.Find("Cannon");
    }

    // Update is called once per frame
    void Update()
    {
        CheckFire();

        Rotate();
    }

    private void Fire()
    {
        Instantiate(ballPrefab, firePoint.transform.position, firePoint.transform.rotation);
    }


    private void CheckFire()
    {
        fireCountDown += Time.deltaTime;

        if (fireCountDown >= 0.1f && Input.GetKey(KeyCode.Space))
        {
            Fire();

            fireCountDown = 0;
        }
    }

    private void Rotate()
    {
        VerticalRotate();
        HorizontalRotate();
    }

    private void VerticalRotate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        
        cannonBase.transform.Rotate(20 * verticalInput * Time.deltaTime, 0, 0);

        if (cannonBase.transform.rotation.eulerAngles.x < 330 && cannonBase.transform.rotation.eulerAngles.x > 320)
        {
            cannonBase.transform.Rotate(-20 * verticalInput * Time.deltaTime, 0, 0);
        }
        else if (cannonBase.transform.rotation.eulerAngles.x > 50 && cannonBase.transform.rotation.eulerAngles.x < 60)
        {
            cannonBase.transform.Rotate(-20 * verticalInput * Time.deltaTime, 0, 0);
        }
    }

    private void HorizontalRotate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        cannon.transform.Rotate(0, 20 * horizontalInput * Time.deltaTime, 0);
    }
}
