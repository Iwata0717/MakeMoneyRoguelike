using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHPController : MonoBehaviour
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
	public void OnUpdate(int hp)
	{
		_text.text = "HP " + hp + "/3";
	}
}
