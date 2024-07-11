using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static int highScore;
    // Start is called before the first frame update
    void Start()
    {
       
        LoadHighScore();
    }

    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    public static void SaveHighScore()
    {
        // Save the high score to PlayerPrefs if current score is higher
        if (Playfield.score > highScore)
        {
            highScore = Playfield.score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Save the PlayerPrefs data
        }
    }
}
