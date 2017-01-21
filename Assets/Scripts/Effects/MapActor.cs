using UnityEngine;
using System.Collections;

public class MapActor : MonoBehaviour
{
	public EffectClass Effect;

	internal bool Active;

	public void Action() {
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
