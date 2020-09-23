using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
	public bool _isPlayerTurn = true;

	//
	public bool GetIsPlayerTurn()
	{
		return _isPlayerTurn;
	}

	//
	public void ChangeIsPlayerTurn()
	{
		_isPlayerTurn = !_isPlayerTurn;
	}
}
