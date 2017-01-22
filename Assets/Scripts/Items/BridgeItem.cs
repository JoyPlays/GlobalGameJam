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
		
		if (Active) return;
		Active = true;
		StartCoroutine(Crash());
	}

	IEnumerator Crash()
	{
		yield return new WaitForSeconds(0.05f);
		
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().isKinematic = false;
		GetComponent<Rigidbody>().AddForce(0, -2000, 0);
	}
}
