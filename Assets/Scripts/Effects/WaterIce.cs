using UnityEngine;
using System.Collections;

public class WaterIce : MapActor
{

	public float FreezeTime;

	public Material WaterMaterial;
	public Material IceMaterial;

	public GameObject Colliders;

	

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
		
		while (t > 0)
		{
			float myOffset = Mathf.Lerp(0, 0.5f, 1 - t / FreezeTime);
			//Debug.Log(myOffset);
			render.material.SetFloat("_MoveSpeedU", 0.5f - myOffset);
			render.material.SetFloat("_MoveSpeedV", myOffset - 0.5f);
			t -= Time.deltaTime;
			yield return null;
		}
		yield return new WaitForSeconds(1);

		render.material = IceMaterial;
		Colliders.SetActive(true);
		EndAnction();
	}

	
}
