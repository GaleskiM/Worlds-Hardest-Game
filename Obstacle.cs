using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 4f;

    [SerializeField]
    private bool moveLeft;

    private void Update()
    {
        if (moveLeft)
        {
            Vector2 temp = transform.position;
            temp.y -= moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            Vector2 temp = transform.position;
            temp.y += moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bounce")
        {
            moveLeft = !moveLeft;
        }
    }
}