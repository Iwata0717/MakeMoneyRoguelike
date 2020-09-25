using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DungeonManager : MonoBehaviour
{
	private const int _mapWidth = 10;
	private const int _mapHeight = 10;
	private static bool[,] _map = new bool[_mapHeight, _mapWidth];

	[SerializeField] private SpriteRenderer Floor = null;
	[SerializeField] private SpriteRenderer Wall = null;

	//
	private void Awake()
	{
		for (int i = 0; i < _mapHeight; i++)
		{
			for (int j = 0; j < _mapWidth; j++)
			{
				//端だったら壁を生成
				if(i == 0 || i == _mapHeight - 1 || j == 0 || j == _mapWidth - 1)
				{
					_map[j, i] = false;
					Instantiate(Wall, new Vector2(j, -i), Quaternion.identity);
				}

				//それ以外だったら床を生成
				else
				{
					_map[j, i] = true;
					Instantiate(Floor, new Vector2(j, -i), Quaternion.identity);
				}
			}
		}
	}

	//
	public int GetMapWidth()
	{
		return _mapWidth;
	}

	//
	public int GetMapHeight()
	{
		return _mapHeight;
	}

	//
	public bool GetMap(int x, int y)
	{
		return _map[y, x];
	}

	//
	public void SetMap(int x, int y)
	{
		_map[y, x] = !_map[y, x];
	}
}
