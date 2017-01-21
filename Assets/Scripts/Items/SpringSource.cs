using UnityEngine;
using System.Collections;

public class SpringSource : MonoBehaviour
{
	bool Active;

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && !Active)
		{
			Active = true;
			StartCoroutine(FillMana());
		}
	}

	public void OnTriggerExit(Collider other)
	{
		Active = false;
	}

	IEnumerator FillMana()
	{
		while (Active)
		{
			PlayerControler.Mana += 0.1f;
			if (PlayerControler.Mana > 1)
			{
				PlayerControler.Mana = 1;
			}

			yield return new WaitForSeconds(0.3f);

		}
	}
}
