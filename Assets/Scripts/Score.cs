using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score instance;


    public  TextMeshProUGUI text;
    public  TextMeshProUGUI highScoreText;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateScoreText();
        UpdateHighScoreText();
    }

    public  void UpdateScoreText()
    {
       text.text = "Score: " + Playfield.scoreno.ToString();
    }
    public  void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + HighScoreManager.highScore.ToString();
    }
}
