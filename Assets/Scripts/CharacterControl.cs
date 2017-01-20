using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

	[Range(0, 500)]
	public float JumpForce;
	[Range(0,100)]
	public float RunForce;

	public Transform Ground;

	Rigidbody Rigidbody;
	// Use this for initialization
	void Start () {
		Rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 force = Rigidbody.velocity;

		force.x = Input.GetAxis("Horizontal") * RunForce;
		Rigidbody.velocity = force;

		if (Input.GetButton("Fire1") && CheckGround())
		{
			//force.y = JumpForce;
			Rigidbody.AddForce(0,JumpForce,0);
		}

		

	}

	bool CheckGround()
	{
		Collider[] ground = Physics.OverlapSphere(Ground.position, 0.1f, LayerMask.GetMask("Ground"));
		return ground.Length > 0;
	}
}
