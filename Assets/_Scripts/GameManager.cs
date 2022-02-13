using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public int score;
    public int highScore;
    public int enemyDefeated = 0;
    private AudioSource noise;


    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        noise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Start()
    {
        //update score and highscore
        UIManager.Instance.UpdateScore(score);
        UIManager.Instance.UpdateHighScore(PlayerPrefs.GetInt("HighScore", highScore));
 

    }
    private void Update()
    {
        //reset score if backspace is pressed
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ResetHighScore();
        }
        //update highscore
        UIManager.Instance.UpdateHighScore(PlayerPrefs.GetInt("HighScore", highScore));
    }
    public void IncreaseScore()
    {
        //Random number between 100 to 200 will be added to score
        score += Random.Range(100, 200);

        //highscore will be updataed
        IncreaseHighScore();
        noise.Play();

        //score and highscore to be displayed on UI
        UIManager.Instance.UpdateScore(score);
        UIManager.Instance.UpdateHighScore(PlayerPrefs.GetInt("HighScore", highScore));



    }
    public void IncreaseHighScore()
    {
        //using playerprefs to set new highscore if its over the current highscore value

        //highScore = 0;
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;

        }

    }
    public void ResetHighScore()
    {
        // delete key and update highscore value to 0

        PlayerPrefs.DeleteKey("HighScore");
        UIManager.Instance.UpdateHighScore(0);
    }
    public void EnemyDefeated()
    {
        enemyDefeated++;

    }
}
