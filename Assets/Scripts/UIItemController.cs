using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemController : MonoBehaviour
{
	private Text _text = null;

	/// <summary>
	/// Start
	/// </summary>
	private void Start()
	{
		_text = GetComponent<Text>();
	}

	/// <summary>
	/// OnUpdate
	/// </summary>
	/// <param name="hp"></param>
	public void OnUpdate(int value)
	{
		if(value == 10)
		{
			_text.text = "Coin " + value + "/ 10";
		}
		else
		{
			_text.text = "Coin  " + value + "/ 10";
		}
	}
}
