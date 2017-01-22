using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneUi : MonoBehaviour
{

	public void LoadGame()
	{
		SceneManager.LoadScene("MainGame");
	}
}
