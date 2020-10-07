using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColliderManager : StatesBase
{
	private static bool[,] _characterCollider = null;

	//
	public override void OnStart()
	{
		_characterCollider = new bool[Managers.Dungeon.GetMapHeight(), Managers.Dungeon.GetMapWidth()];

		for (int i = 0; i< Managers.Dungeon.GetMapHeight(); i++)
		{
			for (int j = 0; j < Managers.Dungeon.GetMapWidth(); j++)
			{
				_characterCollider[i, j] = true;
			}
		}
	}

	//
	public override void OnUpdate()
	{

	}

	//
	public bool GetCollider(int x, int y)
	{
		return _characterCollider[y, x];
	}

	//
	public void SetCollider(int x, int y)
	{
		_characterCollider[y, x] = !_characterCollider[y, x];
	}
}
