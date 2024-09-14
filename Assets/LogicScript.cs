using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text highScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource coin;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        coin.Play();

        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScore.text = playerScore.ToString();
            highScore.color = Color.yellow;
        }
        
    }

    public void reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void returnToMenu()
    {
        SceneManager.LoadSceneAsync("TitleCard");
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
