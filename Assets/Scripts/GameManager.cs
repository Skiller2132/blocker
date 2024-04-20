using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float speed;
    public int score;
    public Text scoreText;
    public int lives;
    public Text livesText;
    public Text highScoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;
    public int numberOfBricks;
    public Transform[] levels;
    public GameObject[] unbreakableBricks;
    public int currentLevelIndex = 0;
    public GameObject ball;
    public Transform paddle;

    // Start is called before the first frame update
    void Start()
    {

        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
        Instantiate(levels[currentLevelIndex],Vector2.zero,Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length - 1;
        unbreakableBricks = GameObject.FindGameObjectsWithTag("unbreakable");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;

    }
    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        livesText.text = "Lives: " + lives;

        if (lives <= 0 )
        {
            lives = 0;
            GameOver();
        }
    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks<=0)
        {
            if (currentLevelIndex >= levels.Length - 1)
            {
                 GameOver();
            }
            else
            {
                gameOver = true;
                nextLevelPanel.SetActive(true);
                nextLevelPanel.GetComponentInChildren<Text> ().text = "Level " + (currentLevelIndex + 1) + " completed!";
            }  
        }
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", (score - 1));
            highScoreText.text = "New High Score: " + highScore;
        }
        else
        {
            highScoreText.text = "Score: " + (score - 1) + "\nHigh score:" + highScore;
        }
    }
    public void NextLevel()
    {
        nextLevelPanel.GetComponentInChildren<Text> ().text = "Level " + (currentLevelIndex + 2) + "\nCompleted!";
        foreach(GameObject unbreakableBricks in unbreakableBricks)
            GameObject.Destroy(unbreakableBricks);
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex],Vector2.zero,Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length - 1;
        ball.transform.position = paddle.position;
        nextLevelPanel.SetActive(false);
        gameOver = false;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void Quit()
    {
        SceneManager.LoadScene("StartMenu");
    }

}
