using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
	/// <summary>
	/// _isPlayerTurn
	/// </summary>
	private bool _isPlayerTurn = true;

	/// <summary>
	/// GetIsPlayerTurn
	/// </summary>
	/// <returns></returns>
	public bool GetIsPlayerTurn()
	{
		return _isPlayerTurn;
	}

	/// <summary>
	/// ChangeIsPlayerTurn
	/// </summary>
	public void ChangeIsPlayerTurn()
	{
		_isPlayerTurn = !_isPlayerTurn;
	}
}
