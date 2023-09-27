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

    private void Start()
    {
        //Initialises UpdateHighscore function
        UpdateHighscore();
    }

    //Counts player score
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        //Counts player score
        playerScore = playerScore + scoreToAdd;

        //Updates Score Text
        scoreText.text = playerScore.ToString();

        //Initialises CheckHighscore function
        CheckHighscore();
    }

    void CheckHighscore()
    {
        //If the highscore is lower than the playscore this will update the highscore
        if (highscore < playerScore)
            PlayerPrefs.SetInt("highscore", playerScore);

        //Initialises UpdateHighscore function
        UpdateHighscore();
    }

    void UpdateHighscore()
    {   
        //Defines the highscore
        highscore = PlayerPrefs.GetInt("highscore", 0);

        //Update hihghscore text
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    //function to activate the gameover screen
    public void gameOver()
    {
        //Activates the gameover screen
        gameOverScreen.SetActive(true);
    }

    //Function to restart the game
    public void restartGame()
    {
        //Reloads the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Returns to Title Screen
    public void returnToTitleScreen()
    {   
        //loads the titlescreen level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}
