using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
	[Header("Physics")]
	[Range(0,10)]
	public float jumpHeight = 5;
	[Range(0,200)]
	public float runSpeed = 70;
	[Range(0,50)]
	public float frictionX = 10;
	[Range(0, 50)]
	public float frictionY = 5;
	
	[Header("Effects")]
	public EffectClass WaterfallEffect;

	private CharacterController controller;
	internal Vector3 velocity;

	void Awake()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{

		if (Input.GetKey("1") && controller.isGrounded)
		{
			WaterfallEffect.SpawnEffect();
			velocity.y = 7;
			return;
		}

		// Grounded states
		if (controller.isGrounded || WaterfallEffect.Active)
		{
			velocity.x -= velocity.x * frictionX * Time.deltaTime;
			velocity.z -= velocity.z * frictionX * Time.deltaTime;
			if (WaterfallEffect.Active)
			{

				//velocity.y = 7;
			} else
			{
				velocity.y -= frictionY;
			}
					

			// Run Input
			Quaternion camRot = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
			velocity += camRot * new Vector3(Input.GetAxis("Horizontal"), 0, 0) * runSpeed * Time.deltaTime;
		}
		else
		{
			velocity += Physics.gravity * Time.deltaTime;
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
		Debug.Log("Trigger enter");
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
