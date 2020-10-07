using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawnManager : MonoBehaviour
{
	//
	public GameObject CharacterSpawn(GameObject character)
	{
		GameObject obj;
		int x, y;

		while (true)
		{
			x = Random.Range(1, Managers.Dungeon.GetMapWidth() - 1);
			y = Random.Range(1, Managers.Dungeon.GetMapHeight() - 1);
			if (Managers.Dungeon.GetMap(x, y))
			{
				obj = Instantiate(character, new Vector2(x, y), Quaternion.identity);
				Managers.CharacterCollider.SetCollider(x, y);
				break;
			}
		}
		return obj;
	}
}
