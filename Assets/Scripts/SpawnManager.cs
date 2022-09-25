using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	/// <summary>
	/// CharacterSpawn
	/// </summary>
	/// <param name="character"></param>
	/// <returns></returns>
	public GameObject Spawn(GameObject pregab, bool isCharactor)
	{
		GameObject obj;
		int x, y;

		while (true)
		{
			x = Random.Range(1, Managers.Dungeon.GetMapWidth() - 1);
			y = Random.Range(1, Managers.Dungeon.GetMapHeight() - 1);
			if (Managers.Dungeon.GetMap(x, y))
			{
				obj = Instantiate(pregab, new Vector2(x, y), Quaternion.identity);
				if(isCharactor)
				{
					Managers.CharacterCollider.SetCollider(x, y);
				}
				break;
			}
		}
		return obj;
	}
}
