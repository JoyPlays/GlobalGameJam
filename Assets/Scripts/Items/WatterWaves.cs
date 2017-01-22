using UnityEngine;
using System.Collections;

public class WatterWaves : MonoBehaviour
{
	[Range(-2, 2)]
	public float speedX;
	[Range(-2, 2)]
	public float speedY;

	[Range(0, 2)]
	public float sine;
	// Update is called once per frame
	void Update()
	{
		float w = Mathf.Sin(Time.time * sine);
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(w * speedX, Time.time * speedY));
	}
}
