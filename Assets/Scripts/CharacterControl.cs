using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

	public static float Mana;

	[Range(0, 500)]
	public float JumpForce;
	[Range(0, 100)]
	public float RunForce;

	[Header("Effects")]
	public EffectClass WaterfallEffect;

	public Transform Ground;

	Rigidbody Rigidbody;
	// Use this for initialization
	void Start()
	{
		Rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{

		Vector3 force = Rigidbody.velocity;
		RigidbodyConstraints constr = RigidbodyConstraints.FreezeRotation;
		if (CameraControl.Camera.Type == RotateType.Zero || CameraControl.Camera.Type == RotateType.Rear)
		{
			force.x = Input.GetAxis("Horizontal") * RunForce * (CameraControl.Camera.Type == RotateType.Rear ? -1 : 1);
			Rigidbody.constraints = constr | RigidbodyConstraints.FreezePositionZ;
		} else
		{
			force.z = Input.GetAxis("Horizontal") * RunForce * (CameraControl.Camera.Type == RotateType.Left ? -1 : 1);
			Rigidbody.constraints = constr | RigidbodyConstraints.FreezePositionX;
		}
		Rigidbody.velocity = force;

		bool grounded = CheckGround();

		if (Input.GetButton("Jump") && grounded)
		{
			Rigidbody.AddForce(0, JumpForce, 0);
		}

		if (Input.GetKey("1") && grounded)
		{
			WaterfallEffect.SpawnEffect();
		}

	}

	bool CheckGround()
	{
		Collider[] ground = Physics.OverlapSphere(Ground.position, 0.1f, LayerMask.GetMask("Ground"));
		return ground.Length > 0;
	}

	public void OnTriggerEnter(Collider other)
	{

		CameraRotor rotor = other.GetComponentInParent<CameraRotor>();
		if (rotor)
		{
			rotor.SetCameraRotation(other.gameObject.tag);
			return;
		}
		

		MapActor actor = other.GetComponent<MapActor>();
		if (!actor) return;


		actor.Action();
	}
}
