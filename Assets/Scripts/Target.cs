//INHERITANCE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private bool isMovingRight;
    private float moveSpeed;
    private float moveMin = 0.01f;
    private float moveMax = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartMove(); //ABSTRACTION
    }

    // Update is called once per frame
    void Update()
    {
        Move(); //ABSTRACTION
    }

    protected void Move()
    {
        if (isMovingRight)
        {
            transform.Translate(moveSpeed, 0, 0);
        }
        else
        {
            transform.Translate(-moveSpeed, 0, 0);
        }
    }

    private void StartMove()
    {
        isMovingRight = RandomBool();

        moveSpeed = Random.Range(moveMin, moveMax);
    }

    private bool RandomBool()
    {
        return (Random.value > 0.5f);
    }
}
