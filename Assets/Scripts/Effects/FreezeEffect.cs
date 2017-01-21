using UnityEngine;
using System.Collections;

public class FreezeEffect : EffectClass
{
	public override void SpawnEffect()
	{
		gameObject.SetActive(true);
	}
	public override void StopEffect()
	{
		gameObject.SetActive(false);
	}
}
