using UnityEngine;
using System.Collections;

public class ShotingEffect : MapActor
{
	public MapActor Actor;

	protected override void DoAction()
	{
		Animator anim = GetComponent<Animator>();
		if (anim)
		{
			Debug.Log("Shot");
			anim.SetTrigger("Trap");
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && !Active && !Actor.Active)
		{
			Active = true;
			DoAction();
		}
	}
}
