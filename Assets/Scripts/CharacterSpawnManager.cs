using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawnManager : MonoBehaviour
{
	[SerializeField] private DungeonManager _dungeonManager = null;

	//
	public GameObject CharacterSpawn(GameObject character)
	{
		GameObject obj;
		int x, y;

		while (true)
		{
			x = Random.Range(1, _dungeonManager.GetMapWidth() - 1);
			y = Random.Range(1, _dungeonManager.GetMapHeight() - 1);
			if (_dungeonManager.GetMap(x, y))
			{
				obj = Instantiate(character, new Vector2(x, y), Quaternion.identity);
				_dungeonManager.SetMap(x, y);
				break;
			}
		}
		return obj;
	}
}
