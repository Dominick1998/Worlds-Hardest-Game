using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int lives; // Number of lives the player has
    public int level; // Current level the player is on
    Text scoreText; // UI Text element to display the player's lives
    Text levelText; // UI Text element to display the current level
    Vector2 initPos; // Initial position of the player
    public float moveSpeed; // Speed at which the player moves
    public AudioSource audio; // Audio source for playing sounds

    // Start is called before the first frame update
    void Start()
    {
        // Initialize variables
        initPos = transform.position; // Set initial position
        lives = 3; // Set initial number of lives
        scoreText = GameObject.Find("Canvas/Text").GetComponent<Text>(); // Find and set the score text UI element
        levelText = GameObject.Find("Canvas/LevelText").GetComponent<Text>(); // Find and set the level text UI element
        moveSpeed = 0.08f; // Set the movement speed
        level = 1; // Set the initial level
        audio = GetComponent<AudioSource>(); // Get the audio source component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UI text elements with the current lives and level
        scoreText.text = "Lives: " + lives;
        levelText.text = "Level " + level;
    }

    // FixedUpdate is called at a fixed interval and is used for physics updates
    private void FixedUpdate()
    {
        // Check for player input and move the player accordingly
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * moveSpeed); // Move right
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * moveSpeed); // Move left
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * moveSpeed); // Move up
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * moveSpeed); // Move down
        }
    }

    // Called when the player collides with another collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            audio.Play(); // Play audio on collision with an enemy
            if (lives > 0)
            {
                transform.position = initPos; // Reset position to the initial position
                lives--; // Decrease the number of lives
            }
            else
            {
                // Stop the game if no lives are left
                UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
            }
        }
        if (collision.CompareTag("Goal"))
        {
            // Notify the GameManager that the goal has been reached
            GameManager.gm.ReachedGoal();
        }
    }
}
