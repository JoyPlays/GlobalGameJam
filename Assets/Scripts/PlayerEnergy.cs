using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerEnergy : MonoBehaviour
{

	List<GameObject> Items = new List<GameObject>();
	// Use this for initialization
	void Start()
	{
		foreach (Transform tr in transform)
		{
			Items.Add(tr.gameObject);
			tr.gameObject.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update()
	{
		int c = (int) (Items.Count * PlayerControler.Mana);
		for (int i = 0; i < Items.Count; i++)
		{
			Items[i].SetActive(i < c);
		}
	}
}
