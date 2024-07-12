using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
  
    public Spawner spawner;
  
    public GameObject gameoverpanel;
    public GameObject mainmenupanel;
   // public GameObject scorepanel;

    public void Start()
    {
       
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        mainmenupanel.SetActive(true);
        gameoverpanel.SetActive(false);
      //  scorepanel.SetActive(false);
    }
    public void PlayBtn()
    { 
        mainmenupanel.SetActive(false);
       // scorepanel.SetActive(true);
        StartGame();
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        spawner.SpwanNext();
    }
    public void GameOver()
    {
        Debug.Log("GAME OVER");
        gameoverpanel.SetActive(true);
        Time.timeScale = 0;
        HighScoreManager.SaveHighScore();
    }
    public void Restart()
    {
        gameoverpanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //if (FindObjectOfType<Playfield>() != null)
        //{
        //    FindObjectOfType<Playfield>().ClearPlayfield();
        //    StartGame();
        //}
        //else
        //{
        //    Debug.Log("Error");
        //}
    }
}