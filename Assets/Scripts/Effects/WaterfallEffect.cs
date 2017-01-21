using UnityEngine;
using System.Collections;

public class WaterfallEffect : EffectClass
{
	[Range(0,2)]
	public float FlyTime;
	public AnimationCurve Path;
	public Transform Platform;

	public override void SpawnEffect()
	{
		
		if (Active) return;
		Active = true;
		gameObject.SetActive(true);
		StartCoroutine(MovePlatform());
	}

	IEnumerator MovePlatform()
	{
		Vector3 target = Platform.localPosition;
		Vector3 start = Platform.localPosition;
		//target.y = 0;
		float t = FlyTime;
		while (t > 0)
		{
			start.y = target.y - target.y * Path.Evaluate(1 - t / FlyTime);
			Platform.localPosition = start;
			t -= Time.deltaTime;
			yield return null;
		}
		Platform.localPosition = target;
		gameObject.SetActive(false);
		Active = false;
	}
}
