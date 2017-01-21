using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesTrigger : MonoBehaviour {

	private void OnTriggerEnter(Collider spike)
	{
		if (spike.gameObject.CompareTag("Player"))
		{
			PlayerControler.Ded();
			print("Collision");
		}
	}
}
