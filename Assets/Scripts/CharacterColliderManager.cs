using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColliderManager : StatesBase
{
	private static bool[,] _objectCollider = null;

	/// <summary>
	/// OnStart
	/// </summary>
	public override void OnStart()
	{
		_objectCollider = new bool[Managers.Dungeon.GetMapHeight(), Managers.Dungeon.GetMapWidth()];

		for (int i = 0; i< Managers.Dungeon.GetMapHeight(); i++)
		{
			for (int j = 0; j < Managers.Dungeon.GetMapWidth(); j++)
			{
				_objectCollider[i, j] = true;
			}
		}
	}

	/// <summary>
	/// OnUpdate
	/// </summary>
	public override void OnUpdate()
	{

	}

	/// <summary>
	/// GetCollider
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public bool GetCollider(int x, int y)
	{
		return _objectCollider[y, x];
	}

	/// <summary>
	/// SetCollider
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	public void SetCollider(int x, int y)
	{
		_objectCollider[y, x] = !_objectCollider[y, x];
	}
}
