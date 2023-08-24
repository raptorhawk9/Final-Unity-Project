using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private Rigidbody ballRb;
    private GameObject cannon;
    [SerializeField] private float cannonPower;
    
    // Start is called before the first frame update
    void Awake()
    {
        ballRb = GetComponent<Rigidbody>();

        cannon = GameObject.Find("Barrel");

        ballRb.AddForce(cannon.transform.up * cannonPower, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOutOfBounds();
    }

    void DestroyOutOfBounds()
    {
        if (transform.position.y < -200)
        {
            Destroy(gameObject);
        }
    }
}
