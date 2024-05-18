using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int lives;
    public int level;
    Text scoreText;
    Text levelText;
    Vector2 initPos;
    public float moveSpeed;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        lives = 3;
        scoreText = GameObject.Find("Canvas/Text").GetComponent<Text>();
        levelText = GameObject.Find("Canvas/LevelText").GetComponent<Text>();
        moveSpeed = 0.08f;
        level = 1;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Lives: " + lives;
        levelText.text = "Level " + level;
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * moveSpeed);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * moveSpeed);
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * moveSpeed);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * moveSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            audio.Play();
            if (lives > 0)
            {
                transform.position = initPos;
                lives--;
            }
            else
            {
                UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
            }
        }
        if(collision.CompareTag("Goal"))
        {
            GameManager.gm.ReachedGoal();
        }
    }
}
