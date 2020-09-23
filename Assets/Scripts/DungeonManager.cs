using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
	private static bool[,] _room = new bool[10, 10]{
		{false,false,false,false,false,false,false,false,false,false},
		{false,true,true,true,true,true,true,true,true,false},
		{false,true,true,true,true,true,true,true,true,false},
		{false,true,true,true,true,true,true,true,true,false},
		{false,true,true,true,true,true,true,true,true,false},
		{false,true,true,true,true,true,true,true,true,false},
		{false,true,true,true,true,true,true,true,true,false},
		{false,true,true,true,true,true,true,true,true,false},
		{false,true,true,true,true,true,true,true,true,false},
		{false,false,false,false,false,false,false,false,false,false}
	};

	[SerializeField] private SpriteRenderer Floor = null;
	[SerializeField] private SpriteRenderer Block = null;

	//
	private void Awake()
	{
		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 10; j++)
			{
				switch (_room[i, j])
				{
					case false:
						Instantiate(Block, new Vector2(j, -i), Quaternion.identity);
						break;

					case true:
						Instantiate(Floor, new Vector2(j, -i), Quaternion.identity);
						break;
				}
			}
		}
	}

	//
	public bool GetRoom(int x,int y)
	{
		return _room[y,x];
	}

	//
	public void SetRoom(int x, int y)
	{
		_room[y, x] = !_room[y, x];
	}
}
