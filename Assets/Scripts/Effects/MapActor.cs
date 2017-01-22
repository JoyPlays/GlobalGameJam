using UnityEngine;
using System.Collections;

public class MapActor : MonoBehaviour
{
	public float Mana = 0.1f;
	public EffectClass Effect;

	internal bool Active;
	internal string key;

	public void Action()
	{
		if (Active) return;
		Active = true;
		if (Effect) Effect.SpawnEffect();
		DoAction();
	}

	protected virtual void EndAnction()
	{
		if (Effect) Effect.StopEffect();
	}
	protected virtual void DoAction() { }

	
}
