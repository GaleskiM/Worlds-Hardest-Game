using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public GameObject[] obstacle;

    void Awake()
    {
        if (instance == null)
            instance = this;

        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
        player = GameObject.FindWithTag("Player");

    }

    public void PlayerWins()
    {
        Debug.Log("You WON!");
        player.GetComponent<Movement>().speed += .3f;

        {
            foreach (GameObject g in obstacle)
            {
                g.GetComponent<Obstacle>().moveSpeed += 1f;
            }
        }
    }

    public void PlayerDied()
    {
        Time.timeScale = 0f;
        Debug.Log("Player Died!");
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}