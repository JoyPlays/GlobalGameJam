using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
	public static float Mana=0f;
	private Animator anim;

	[Header("Physics")]
	[Range(0,100)]
	public float jumpHeight = 5;
	[Range(0,500)]
	public float runSpeed = 70;
	[Range(0,200)]
	public float frictionX = 10;
	[Range(0, 50)]
	public float frictionY = 5;
	


	private CharacterController controller;
	internal Vector3 velocity;

	internal static bool IsDed;

	static PlayerControler instance;

	void Awake()
	{
		controller = GetComponent<CharacterController>();
		anim = GetComponentInChildren<Animator>();
		instance = this;
	}

	public static void Ded()
	{
		IsDed = true;
		instance.anim.SetTrigger("Dead");
	}

	public static void Rotate()
	{

	}

	void Update()
	{
		if (IsDed) return;


		transform.localEulerAngles = CameraControl.Camera.transform.localEulerAngles;
		// Grounded states
		if (controller.isGrounded)
		{
				velocity.z -= velocity.z * frictionX * Time.deltaTime;
				velocity.x -= velocity.x * frictionX * Time.deltaTime;

			velocity.y -= frictionY;

			anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

			// Run Input
			Quaternion camRot = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
			velocity += camRot * new Vector3(Input.GetAxis("Horizontal"), 0, 0) * runSpeed * Time.deltaTime;

		}
		else
		{
			velocity += Physics.gravity;
		}

		// Jump Input
		if (Input.GetButton("Jump") && controller.isGrounded)
		{
			//Debug.Log("Jump is ground:" + controller.isGrounded);
			velocity.y = jumpHeight;
		}

		// Move the controller
		controller.Move(velocity * Time.deltaTime);
	}

	public void OnTriggerEnter(Collider other)
	{
		Debug.Log("Trigger enter:" + other.name);
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
