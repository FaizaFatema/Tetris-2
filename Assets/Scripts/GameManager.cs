using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameoverpanel;

   

    public void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        
    }
    public void GameOver()
    {
        Debug.Log("GAME OVER");
        gameoverpanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        gameoverpanel.SetActive(false);
        Time.timeScale = 1;
        if (Playfield.Instance != null)
        {
           Playfield.Instance.ClearPlayfield();
        }
        else
        {
            Debug.Log("Error");
        }
    }
}