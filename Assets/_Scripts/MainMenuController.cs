using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuController : MonoBehaviour
{
	//audio variable
	public AudioMixer audioMixer;

	void Awake()
	{
		//unlock cursor and set visibility to true
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	public void setQuality(int quality)
    {
		//set quality in dropdown
		QualitySettings.SetQualityLevel(quality);
    }
	public void SetVolume (float volume)
    {
		//set volume
		audioMixer.SetFloat("vol", volume);
    } 
	public void LoadGreenMap()
	{
		//load scene index 1
		SceneManager.LoadSceneAsync(1);
	}	
	public void LoadWinterMap()
	{
		//load scene index 2
		SceneManager.LoadSceneAsync(2);
	}
	public void ButtonMenu()
	{
		//load scene index 0
		SceneManager.LoadSceneAsync(0);
	}

	public void QuitGame()
    {
		//Close application
		Application.Quit();
    }
}
