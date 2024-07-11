using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score instance;

    public TextMeshProUGUI text;

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
    }

    public void UpdateScoreText()
    {
        text.text = "Score: " + Playfield.score.ToString();
    }
}
