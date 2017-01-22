using UnityEngine;
using System.Collections;

public class EffectClass : MonoBehaviour
{
	internal bool Active;

	public float Mana;

	public virtual void SpawnEffect()
	{
		gameObject.SetActive(true);
	}
	public virtual void StopEffect()
	{
		gameObject.SetActive(false);
	}
}
