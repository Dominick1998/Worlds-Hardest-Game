using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public bool moveLeft;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
            transform.Translate(Vector2.left * moveSpeed);
        else
            transform.Translate(Vector2.right * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bounce"))
        {
            moveLeft = !moveLeft;
        }

    }

}
