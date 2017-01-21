using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gui : MonoBehaviour
{

	public Slider ManaSlider;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (ManaSlider)
		{
			ManaSlider.value = CharacterControl.Mana;
		}
	}
}
