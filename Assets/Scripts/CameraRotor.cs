using UnityEngine;
using System.Collections;

public class CameraRotor : MonoBehaviour
{
	public RotateType LeftSide;
	public RotateType RightSide;

	public void SetCameraRotation(string tag)
	{
		Debug.Log("Start rotation:" + tag);
		if (tag.Equals("CameraZero"))
		{
			CameraControl.Camera.Type = LeftSide;
			return;
		}
		if (tag.Equals("CameraRight"))
		{
			CameraControl.Camera.Type = RightSide;
			return;
		}
		if (tag.Equals("CameraBoth"))
		{
			CameraControl.Camera.Type = CameraControl.Camera.Type == LeftSide ? RightSide : LeftSide;
			return;
		}

	}
}
