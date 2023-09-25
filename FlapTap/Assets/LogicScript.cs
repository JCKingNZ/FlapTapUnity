using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    //Defining different variables and objects
    public int playerScore;
    public Text scoreText;
    public int highscore;
    public Text highscoreText;
    public GameObject gameOverScreen;

    void Start()
    { 
        //determines the current highscore and shows it upon game start.
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    //Counts player score
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        //Counts player score
        scoreText.text = playerScore.ToString();
        playerScore = playerScore + scoreToAdd;
        //If the highscore is lower than the playscore this will update the highscore
        if (highscore < playerScore)
            PlayerPrefs.SetInt("highscore", playerScore);


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
