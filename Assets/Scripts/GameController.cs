using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardBoxWaveCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public TextMesh scoreText;
    public TextMesh restartText;
    public TextMesh gameOverText;
    private bool gameOver;
    private bool restart;
    //public Text scoreText;
    private int score;
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0;i < hazardBoxWaveCount;i++)
            {
                float xPos = Random.Range(-spawnValues.x, 75);
                Vector3 spawnPosition = new Vector3(xPos,spawnValues.y,spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        restart = false;
        gameOver = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score; //automatically converted to single string of text characters
    }
    public void AddScore(int newScoreValue)
    {
        //Debug.Log(score);
        score += newScoreValue;
        //Debug.Log(newScoreValue);
        UpdateScore();
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
