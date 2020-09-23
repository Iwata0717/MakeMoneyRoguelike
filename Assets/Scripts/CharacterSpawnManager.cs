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
			x = Random.Range(0, 10);
			y = Random.Range(0, 10);
			if (_dungeonManager.GetRoom(x, y))
			{
				obj = Instantiate(character, new Vector2(x, -y), Quaternion.identity);
				_dungeonManager.SetRoom(x, y);
				break;
			}
		}
		return obj;
	}
}
