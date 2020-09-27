using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
	private const int _mapWidth = 50;
	private const int _mapHeight = 40;
	private static int _maxRooms = 10;
	private int _roomWidth = 8;
	private int _roomHeight = 8;
	private int _minRoad = 3;
	private static bool[,] _map = new bool[_mapHeight, _mapWidth];
	private RoomState[] _rooms = new RoomState[_maxRooms];

	[SerializeField] private SpriteRenderer Floor = null;
	[SerializeField] private SpriteRenderer Wall = null;

	//
	private void Awake()
	{
		for (int i = 0; i < _maxRooms; i++)
		{
			_rooms[i] = new RoomState();
		}
		for (int i = 0; i < _mapHeight; i++)
		{
			for (int j = 0; j < _mapWidth; j++)
			{
				if (i == 0 || i == _mapHeight - 1 || j == 0 || j == _mapWidth - 1)
				{
					_map[i, j] = true;
				}
				else
					_map[i, j] = false;
				/*
				//端だったら壁を生成
				if (i == 0 || i == _mapHeight - 1 || j == 0 || j == _mapWidth - 1)
				{
					_map[i, j] = false;
				}

				//それ以外だったら床を生成
				else
				{
					_map[i, j] = true;
				}*/
			}
		}

		_rooms[0].SetPosition(1, 1);

		MakeLine();

		for (int i = 0; i < _mapHeight; i++)
		{
			for (int j = 0; j < _mapWidth; j++)
			{
				//端だったら壁を生成
				if (_map[i, j])
				{
					Instantiate(Floor, new Vector2(j, -i), Quaternion.identity);
				}

				//それ以外だったら床を生成
				else
				{
					//_map[j, i] = true;
					Instantiate(Wall, new Vector2(j, -i), Quaternion.identity);
				}
			}
		}
	}

	//
	public void MakeLine()
	{
		bool isNextRoom = true;
		int line;
		int room = 1;

		//n回ループする
		for (int i = 0; i < 100; i++)
		{
			if (room < _maxRooms)
			{
				isNextRoom = true;
				
				switch (Random.Range(0, 4))
				{
					//TOP
					case 0:

						//
						line = Random.Range(_roomWidth + 1, _mapWidth - _roomWidth - 1);

						//
						for (int k = line; k <= line + _roomWidth + _minRoad; k++)
						{
							if (_map[1, k])
							{
								isNextRoom = false;
								break;
							}
						}

						for (int k = line; k >= line - _roomWidth - _minRoad; k--)
						{
							if (_map[1, k] || !isNextRoom)
							{
								isNextRoom = false;
								break;
							}
						}

						/*/
						for (int j = 0; j < room; j++)
						{
							if (line >= _rooms[j]._makeRoomPosX - _rooms[j]._roomWidth - _minRoad && line <= _rooms[j]._makeRoomPosX + _rooms[j]._roomWidth + _minRoad)
							{
								isNextRoom = false;
								break;
							}
						}*/

						if (isNextRoom)
						{
							_rooms[room].SetPosition(line + 1, 1);
							room++;

							for (int j = 1; j < _mapHeight - 1; j++)
							{ 
								if (!_map[j, line])
								{
									_map[j, line] = true;
								}
								else
								{
									break;
								}
							}
						}
						break;

					//BOTTOM 
					case 1:

						//
						line = Random.Range(_roomWidth + 1, _mapWidth - _roomWidth - 1);

						//
						for (int k = line; k <= line + _roomWidth + _minRoad; k++)
						{
							if (_map[_mapHeight - 2, k])
							{
								isNextRoom = false;
								break;
							}
						}

						for (int k = line; k >= line - _roomWidth - _minRoad; k--)
						{
							if (_map[_mapHeight - 2, k] || !isNextRoom)
							{
								isNextRoom = false;
								break;
							}
						}

						if (isNextRoom)
						{
							_rooms[room].SetPosition(line + 1, 1);
							room++;

							for (int j = _mapHeight - 2; j > 0; j--)
							{
								if (!_map[j, line])
								{
									_map[j, line] = true;
								}
								else
								{
									break;
								}
							}
						}
						break;

					//LEFT
					case 2:

						//
						line = Random.Range(_roomHeight + 1, _mapHeight - _roomHeight - 1);

						//
						for (int k = line; k <= line + _roomHeight + _minRoad; k++)
						{
							if (_map[k, 1])
							{
								isNextRoom = false;
								break;
							}
						}

						for (int k = line; k >= line - _roomHeight - _minRoad; k--)
						{
							if (_map[k, 1] || !isNextRoom)
							{
								isNextRoom = false;
								break;
							}
						}

						if (isNextRoom)
						{
							_rooms[room].SetPosition(1, line + 1);
							room++;

							for (int j = 1; j < _mapWidth - 1; j++)
							{
								if (!_map[line, j])
								{
									_map[line, j] = true;
								}
								else
								{
									break;
								}
							}
						}
						break;

					//RIGHT
					case 3:

						//
						line = Random.Range(_roomHeight + 1, _mapHeight - _roomHeight - 1);

						//
						for (int k = line; k <= line + _roomHeight + _minRoad; k++)
						{
							if (_map[k, _mapWidth - 2])
							{
								isNextRoom = false;
								break;
							}
						}

						for (int k = line; k >= line - _roomHeight - _minRoad; k--)
						{
							if (_map[k, _mapWidth - 2] || !isNextRoom)
							{
								isNextRoom = false;
								break;
							}
						}

						if (isNextRoom)
						{
							_rooms[room].SetPosition(1, line + 1);
							room++;

							for (int j = _mapWidth - 2; j > 0; j--)
							{
								if (!_map[line, j])
								{
									_map[line, j] = true;
								}
								else
								{
									break;
								}
							}
						}
						break;
				}
			}
			else
			{
				break;
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

//
public class RoomState
{
	public int _makeRoomPosX;
	public int _makeRoomPosY;
	public int _roomWidth = 5;
	public int _roomHeight = 5;

	public void SetPosition(int x, int y)
	{
		_makeRoomPosX = x;
		_makeRoomPosY = y;
	}
}