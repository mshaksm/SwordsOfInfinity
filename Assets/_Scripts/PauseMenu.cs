using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    //boolean for pause
    public static bool Pause= false;
    //pausemenu variable
    public GameObject pauseMenu;
    //cursorlock variable
    CursorLockMode curLock;


    // Update is called once per frame
    void Update()
    {
        //check if escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        
    }

    public void ResumeGame()
    {
        //hide pause menu and set normal game speed, hide and confine cursor in game window
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Pause = false;
        Cursor.visible = false;
        curLock = CursorLockMode.Confined;
    }
    void PauseGame()
    {
        //show pause menu and pause game speed, show cursor
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Pause = true;
        Cursor.visible = true;
        curLock = CursorLockMode.None;
        {
            Cursor.lockState = curLock;
        }

    }
    public void LoadMenu()
    {
        //set game time to normal and load scene index 0
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Retry()
    {
        //set game time to normal and load current scene index
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        //Close application
        Application.Quit();

    }
}
