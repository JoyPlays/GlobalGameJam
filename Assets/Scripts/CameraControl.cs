using UnityEngine;
using System.Collections;
public enum RotateType
{
	Zero,
	Right,
	Rear,
	Left
}
public class CameraControl : MonoBehaviour
{
	public static CameraControl Camera;

	public float minDistance;
	public float followDistance;
	public Transform target;
	public Vector3 offset;

	[Range(0, 1)]
	public float speed = 0.5f;
	[Range(0, 1)]
	public float RotateSpeed = 0.5f;

	internal RotateType Type;

	Vector3 targetPos;
	float interpVelocity;

	internal bool Ded;

	void Awake()
	{
		Camera = this;
	}

	// Use this for initialization
	void Start()
	{
		targetPos = transform.position;
		Type = RotateType.Zero;
	}
	float GetAngle()
	{
		return Type == RotateType.Zero ? 0 : Type == RotateType.Right ? -90 : Type == RotateType.Rear ? 180 : 90;
	}
	void Update()
	{
		if (Ded)
		{
			if (transform.localEulerAngles.x < 40)
			{
				transform.localEulerAngles += new Vector3(1f, 0, 0);
			}
			return;		
		}

		if (target)
		{
			Vector3 posNo = transform.position;
			//posNo.z = target.position.z;
			//posNo.y = target.position.y;

			Vector3 targetDirection = (target.position - posNo);
			

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

			transform.position = Vector3.Lerp(transform.position, targetPos + offset, speed);

			Quaternion targetAngle = Quaternion.Euler(0, GetAngle(), 0);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, targetAngle, RotateSpeed);
			//transform.localEulerAngles = targetAngle;// Vector3.Lerp(transform.localEulerAngles, targetAngle, RotateSpeed);
		}
	}
}