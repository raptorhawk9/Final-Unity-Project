//INHERITANCE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private bool isMovingRight;
    private bool isMovingUp;
    private float moveHorizontalSpeed;
    private float moveVerticalSpeed;
    private float moveMin = 0.01f;
    private float moveMax = 0.07f;
    
    // Start is called before the first frame update
    void Awake()
    {
        StartMove(); //ABSTRACTION
    }

    // Update is called once per frame
    void Update()
    {
        Move(); //ABSTRACTION
        DestroyOutOfBounds();
    }

    protected void Move()
    {
        MoveHorizontal();
        MoveVertical();
    }

    protected void MoveHorizontal()
    {
        if (isMovingRight)
        {
            transform.Translate(moveHorizontalSpeed, 0, 0);
        }
        else
        {
            transform.Translate(-moveHorizontalSpeed, 0, 0);
        }
    }

    protected void MoveVertical()
    {
        if (isMovingUp)
        {
            transform.Translate(0, 0, moveVerticalSpeed);
        }
        else
        {
            transform.Translate(0, 0, -moveVerticalSpeed);
        }
    }

    private void StartMove()
    {
        StartMoveHorizontal();
        StartMoveVertical();
    }

    private void StartMoveHorizontal()
    {
        isMovingRight = RandomBool();

        moveHorizontalSpeed = Random.Range(moveMin, moveMax);
    }
    private void StartMoveVertical()
    {
        isMovingUp = RandomBool();

        moveVerticalSpeed = Random.Range(moveMin, moveMax);
    }

    private bool RandomBool()
    {
        return (Random.value > 0.5f);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        GivePoints(other, 1);
    }

    protected virtual void GivePoints(Collider other, int points)
    {
        if (other.name == "CannonBall(Clone)")
        {
            GameManager.Instance.score += points;
        }
    }

    void DestroyOutOfBounds()
    {
        if (transform.position.y < -170 || transform.position.y > 500 || transform.position.x > 700 || transform.position.x < -700)
        {
            Destroy(gameObject);
        }
    }
}
