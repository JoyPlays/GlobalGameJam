using UnityEngine;
using System.Collections;

public class WaterIce : MapActor
{

	public float FreezeTime;
	public float UnfreezeTime = 3;

	public GameObject Colliders;

	public void Update()
	{
		//GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(Time.time * 0.1f, 0));
	}

	protected override void DoAction()
	{
		if (PlayerControler.Mana >= Mana)
		{
			StartCoroutine(FreezeWatter());
		}
	}

	IEnumerator FreezeWatter()
	{
		Active = true;
		float t = FreezeTime;

		Renderer render = GetComponent<Renderer>();

		Color c = render.material.color;
		while (t > 0)
		{
			c.a = Mathf.Lerp(0, 1, t / FreezeTime);
			render.material.color = c;
			t -= Time.deltaTime;
			yield return null;
		}


		Colliders.SetActive(true);
		EndAnction();

		yield return new WaitForSeconds(UnfreezeTime);
		Colliders.SetActive(false);
		t = 1;
		while (t > 0)
		{
			c.a = Mathf.Lerp(0, 1, 1 - t / FreezeTime);
			render.material.color = c;
			t -= Time.deltaTime;
			yield return null;
		}

		c.a = 1;
		render.material.color = c;
		Active = false;
	}


}
