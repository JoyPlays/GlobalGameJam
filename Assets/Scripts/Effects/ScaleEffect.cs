using UnityEngine;
using System.Collections;

public class ScaleEffect : MapActor
{
	[Range(0, 5)]
	public float SteamTime;

	public GameObject Colliders;
	public Transform ScaleTransform;
	// Use this for initialization
	void Start()
	{
		key = "3";
	}

	protected override void DoAction()
	{
		StartCoroutine(Scale());
	}

	IEnumerator Scale()
	{
		float t = SteamTime;
		while (t > 0)
		{
			float scale = Mathf.Lerp(0, 0.5f, t / SteamTime);

			ScaleTransform.localScale = new Vector3(ScaleTransform.localScale.x, scale, ScaleTransform.localScale.z);

			t -= Time.deltaTime;
			yield return null;
		}

		Colliders.SetActive(false);
		EndAnction();
	}
}
