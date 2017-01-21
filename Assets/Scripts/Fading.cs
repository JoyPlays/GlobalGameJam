using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour {

	LevelManager levelmanager;

	public Button startButton;
	bool pressed = true;

	public void FadeMe()
	{
		//if(startButton.onClick )
		//{
			StartCoroutine(DoFade());
		//}
	}

	IEnumerator DoFade()
	{
		CanvasGroup canvasgroup = GetComponent<CanvasGroup>();
		while (canvasgroup.alpha > 0)
		{
			canvasgroup.alpha -= Time.deltaTime / 2;
			yield return null;
		}
		canvasgroup.interactable = false;
		yield return new WaitForSeconds(2);
		Application.LoadLevel("MapGame");
	}

	
}
