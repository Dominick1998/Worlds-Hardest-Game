using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Vector2 spawnPos;

    private GameObject[] enemies;
    private GameObject player;

    private void Awake()
    {
        if (gm == null)
            gm = this;

        Time.timeScale = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindWithTag("Player");
        spawnPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReachedGoal()
    {
        player.transform.position = spawnPos;
        player.GetComponent<PlayerScript>().moveSpeed += 0.05f;
        player.GetComponent<PlayerScript>().lives += 3;
        player.GetComponent<PlayerScript>().level += 1;

        foreach (GameObject g in enemies)
        {
            g.GetComponent<EnemyScript>().moveSpeed += .05f;
        }

    }

}


