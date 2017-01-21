using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour {

	Fading fading;

	public void LoadLevel()
    {
		fading.FadeMe();
    }

	public void LoadOptions()
	{
		Application.LoadLevel("OptionsMenu");
	}
	
	public void LoadMenu()
	{
		Application.LoadLevel("MainMenu");
	} 

	public void Quit()
	{ 
		Application.Quit();
    }

	public void OnValueChanged(float value)
	{
		AudioListener.volume = value;		
	}
}
