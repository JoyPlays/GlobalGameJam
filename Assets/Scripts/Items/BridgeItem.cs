using UnityEngine;
using System.Collections;

public class BridgeItem : MonoBehaviour
{
	bool Active;

	public void OnCollisionEnter(Collision collision)
	{
		
	}

	public void OnTriggerEnter(Collider other)
	{
		
		if (!other.gameObject.CompareTag("Player")) return;
		Debug.Log(other.gameObject.tag);
		if (Active) return;
		Active = true;
		StartCoroutine(Crash());
	}

	IEnumerator Crash()
	{
		yield return new WaitForSeconds(0.5f);
		Debug.Log("Set gravity");
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().isKinematic = false;
	}
}
