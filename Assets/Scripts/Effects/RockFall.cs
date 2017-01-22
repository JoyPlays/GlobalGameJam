using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RockFall : MapActor
{

	public Transform Rocks;
	public GameObject[] Pilars;

	void Start()
	{
		key = "3";
	}

	protected override void DoAction()
	{
		StartCoroutine(BossFight());
	}

	IEnumerator BossFight()
	{
		yield return new WaitForSeconds(3);

		foreach (GameObject obj in Pilars)
		{
			obj.gameObject.SetActive(false);
		}
		yield return new WaitForSeconds(0.2f);
		foreach (Transform tr in Rocks)
		{
			Rigidbody rg = tr.gameObject.GetComponent<Rigidbody>();

			rg.useGravity = true;
			rg.isKinematic = false;

			rg.AddForce(0, -9000, 0);
			yield return null;
		}

		EndAnction();
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene("WinScene");
	}


}
