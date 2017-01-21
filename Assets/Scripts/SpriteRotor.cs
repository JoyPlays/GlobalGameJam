using UnityEngine;
using System.Collections;

public class SpriteRotor : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.localRotation = CameraControl.Camera.transform.localRotation;
	}
}
