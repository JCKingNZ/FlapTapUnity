using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    //Defining different variables and objects
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    [SerializeField] TextMeshProUGUI HighScoreText;

    //Counts player score
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();

    }

    private void Start()
    {
        UpdateHighScoreText();
    }

    //Keeps high Score
    void checkHighScore()
    {
        if(playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
    }

    void UpdateHighScoreText()
    {
        HighScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    //Shows the game over screen when players die
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    //Restarts the game
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Returns to Title Screen
    public void returnToTitleScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}
