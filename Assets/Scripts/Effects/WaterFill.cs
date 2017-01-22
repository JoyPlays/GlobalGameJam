using UnityEngine;
using System.Collections;

public class WaterFill : MapActor
{
	public float topY;

	[Range(0,3)]
	public float FillTime = 2;
	// Use this for initialization
	void Start()
	{
		key = "2";
	}
	protected override void DoAction()
	{
		Debug.Log("Water fill action");
		StartCoroutine(FillWatter());
	}

	IEnumerator FillWatter()
	{
		float t = FillTime;
		float posY = transform.localPosition.y;
		while (t > 0)
		{
			float y = Mathf.Lerp(posY, topY, 1 - t / FillTime);

			transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);

			t -= Time.deltaTime;
			yield return null;
		}
		EndAnction();
		GetComponent<WaterIce>().enabled = true;
		Destroy(this);
	}
}
