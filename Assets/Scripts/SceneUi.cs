using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneUi : MonoBehaviour
{
	void Update()
	{
		if (Input.anyKey)
		{
			LoadGame();
		}
	}


	public void LoadGame()
	{
		SceneManager.LoadScene("MainGame");
	}
}
