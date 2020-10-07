using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private void Start()
	{
		Managers.Dungeon.OnStart();
		Managers.MiniMap.OnStart();
		Managers.CharacterCollider.OnStart();
		Managers.Player.OnStart();
		Managers.Enemy.OnStart();
	}

	private void Update()
	{
		if (Managers.Turn.GetIsPlayerTurn())
		{
			Managers.Player.OnUpdate();
		}
		else
		{
			Managers.Enemy.OnUpdate();
		}
	}
}
