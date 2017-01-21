using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	void Awake()
	{
		Debug.Log("Music player awake" +GetInstanceID());

		if (instance != null)
		{
			Destroy(gameObject);
			print("Duplicate music player self-destructed");
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	void Start() {

		Debug.Log("Music player start" + GetInstanceID());
	}		
	
	void Update () {
	
	}
}
