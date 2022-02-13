using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    //text variables
    public Text scoreText;
    public Text scoreText2;
    public Text highScoreText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void UpdateScore(int score)
    {
        //Convert int score to a string, to be displayed on text

        scoreText.text = score.ToString();
        scoreText.text = scoreText2.text;

    }

    // Update is called once per frame
    public void UpdateHighScore (int highScore)
    {
        //highscore covert to string for ui text
        highScoreText.text = highScore.ToString();
    }
}
