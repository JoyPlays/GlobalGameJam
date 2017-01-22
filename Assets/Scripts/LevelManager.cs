using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour {

	Fading fading;

	public void LoadGame()
    {
		fading.FadeMe();
    }

	public void LoadLevel(string name)
	{
		Application.LoadLevel(name);
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
