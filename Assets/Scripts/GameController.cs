using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public AudioClip bgm;
    public AudioClip winmusic;
    public AudioClip losemusic;
    public AudioSource MusicSource;
    public int score;
    private bool restart;
    private bool gameOver;
    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves () );
        MusicSource.clip = bgm;
        MusicSource.Play();
    }
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.P))
            {
                SceneManager.LoadScene("main");
            }
        }
    }
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0,hazards.Length)];
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'P' to Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
        if (score >= 100)
        {
            gameOverText.text = "GAME CREATED BY REGIMEO CATAYONG";
            gameOver = true;
            MusicSource.clip = winmusic;
            MusicSource.Play();
        }
    }
    public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        MusicSource.clip = losemusic;
        MusicSource.Play();
    }
}
