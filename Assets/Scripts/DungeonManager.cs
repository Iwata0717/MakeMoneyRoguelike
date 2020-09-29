using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
	private const int _mapWidth = 60;
	private const int _mapHeight = 40;
	private static int _maxRooms = 9;
	public int _currentRooms = 0;
	private const int _minRoomWidth = 7;
	private const int _maxRoomWidth = 15;
	private const int _minRoomHeight = 7;
	private const int _maxRoomHeight = 15;
	private int _minBlockWidth = 10;
	private int _minBlockHeight = 10;
	private static bool[,] _map = new bool[_mapHeight, _mapWidth];
	private RoomState[] _rooms = new RoomState[_maxRooms];
	private GameObject [,] _obj = new GameObject[_mapHeight, _mapWidth];

	[SerializeField] private GameObject Floor = null;
	[SerializeField] private GameObject Wall = null;

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
				//端だったら壁を生成
				if (i == 0 || i == _mapHeight - 1 || j == 0 || j == _mapWidth - 1)
				{
					_map[i, j] = false;
				}

				//それ以外だったら床を生成
				else
				{
					_map[i, j] = true;
				}
			}
		}

		_rooms[_currentRooms].SetPosition(1, 1);
		_currentRooms++;

		MakeLine();
		CreateRoom();
		MakeWall();

		for (int i = 0; i < _mapHeight; i++)
		{
			for (int j = 0; j < _mapWidth; j++)
			{
				//端だったら壁を生成
				if (_map[i, j])
				{
					_obj[i, j] = Instantiate(Floor, new Vector2(j, -i), Quaternion.identity);
				}

				//それ以外だったら床を生成
				else
				{
					_obj[i, j] = Instantiate(Wall, new Vector2(j, -i), Quaternion.identity);
				}
			}
		}
	}

	//
	public void MakeLine()
	{
		bool isNextRoom = true;
		int line;

		//n回ループする
		for (int i = 0; i < 50; i++)
		{
			if (_currentRooms < _maxRooms)
			{
				isNextRoom = true;

				switch (Random.Range(0, 4))
				{
					//TOP
					case 0:

						//
						line = Random.Range(_minBlockWidth + 1, _mapWidth - _minBlockWidth - 1);

						//
						for (int j = 0; j <= _minBlockWidth; j++)
						{
							if (!_map[1, line + j] || !_map[1, line - j])
							{
								isNextRoom = false;
								break;
							}
						}

						if (isNextRoom)
						{
							_rooms[_currentRooms].SetPosition(line + 1, 1);
							_currentRooms++;

							for (int j = 1; j < _mapHeight - 1; j++)
							{
								if (_map[j, line])
								{
									_map[j, line] = false;
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
						line = Random.Range(_minBlockWidth + 1, _mapWidth - _minBlockWidth - 1);

						//
						for (int j = 0; j <= _minBlockWidth; j++)
						{
							if (!_map[_mapHeight - 2, line + j] || !_map[_mapHeight - 2, line - j])
							{
								isNextRoom = false;
								break;
							}
						}

						if (isNextRoom)
						{
							for (int j = _mapHeight - 2; j >= 0; j--)
							{
								if (_map[j, line])
								{
									_map[j, line] = false;
								}
								else
								{
									_rooms[_currentRooms].SetPosition(line + 1, j + 1);
									_currentRooms++;
									break;
								}
							}
						}
						break;

					//RIGHT
					case 2:

						//
						line = Random.Range(_minBlockHeight + 1, _mapHeight - _minBlockHeight - 1);

						//
						for (int j = 0; j <= _minBlockHeight; j++)
						{
							if (!_map[line + j, _mapWidth - 2] || !_map[line - j, _mapWidth - 2])
							{
								isNextRoom = false;
								break;
							}
						}

						if (isNextRoom)
						{
							for (int j = _mapWidth - 2; j >= 0; j--)
							{
								if (_map[line, j])
								{
									_map[line, j] = false;
								}
								else
								{
									_rooms[_currentRooms].SetPosition(j + 1, line + 1);
									_currentRooms++;
									break;
								}
							}
						}
						break;

					//LEFT
					case 3:

						//
						line = Random.Range(_minBlockHeight + 1, _mapHeight - _minBlockHeight - 1);

						//
						for (int j = 0; j <= _minBlockHeight; j++)
						{
							if (!_map[line + j, 1] || !_map[line - j, 1])
							{
								isNextRoom = false;
								break;
							}
						}

						if (isNextRoom)
						{
							_rooms[_currentRooms].SetPosition(1, line + 1);
							_currentRooms++;

							for (int j = 1; j < _mapWidth - 1; j++)
							{
								if (_map[line, j])
								{
									_map[line, j] = false;
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

	public void CreateRoom()
	{
		for (int i = 0; i < _currentRooms; i++)
		{
			int roomWidthSpread = 0;
			int roomHeightSpread = 0;
			int roomWidth = 0;
			int roomHeight = 0;
			int x = 0;
			int y = 0;

			//
			if (_rooms[i].GetMakeRoomPosX() == _mapWidth - _minBlockWidth - 1)
			{
				roomWidth = Random.Range(_minRoomWidth, _minBlockWidth + 1);
				x = Random.Range(_rooms[i].GetMakeRoomPosX(), _rooms[i].GetMakeRoomPosX() + _minBlockWidth - roomWidth + 1);
			}
			else
			{
				for (roomWidthSpread = 0; roomWidthSpread < _maxRoomWidth - _minRoomWidth; roomWidthSpread++)
				{
					if (!_map[_rooms[i].GetMakeRoomPosY(), _rooms[i].GetMakeRoomPosX() + _minBlockWidth + roomWidthSpread])
					{
						roomWidthSpread--;
						break;
					}
				}
				if(_minBlockWidth + roomWidthSpread > _maxRoomWidth)
				{
					roomWidth = Random.Range(_minRoomWidth, _maxRoomWidth + 1);
				}
				else
				{
					roomWidth = Random.Range(_minRoomWidth, _minBlockWidth + roomWidthSpread + 1);
				}
				x = Random.Range(_rooms[i].GetMakeRoomPosX(), _rooms[i].GetMakeRoomPosX() + _minBlockWidth + roomWidthSpread - roomWidth + 1);
			}

			/////////////////////////////////////////////////////////////////////////////////////////////////////////////
			//
			if (_rooms[i].GetMakeRoomPosY() == _mapHeight - _minBlockHeight - 1)
			{
				roomHeight = Random.Range(_minRoomHeight, _minBlockHeight + 1);
				y = Random.Range(_rooms[i].GetMakeRoomPosY(), _rooms[i].GetMakeRoomPosY() + _minBlockHeight - roomHeight + 1);
			}
			else
			{
				for (roomHeightSpread = 0; roomHeightSpread < _maxRoomHeight - _minRoomHeight; roomHeightSpread++)
				{
					if (!_map[_rooms[i].GetMakeRoomPosY() + _minBlockHeight + roomHeightSpread, _rooms[i].GetMakeRoomPosX()])
					{
						roomHeightSpread--;
						break;
					}
				}
				if (_minBlockHeight + roomHeightSpread > _maxRoomHeight)
				{
					roomHeight = Random.Range(_minRoomHeight, _maxRoomHeight + 1);
				}
				else
				{
					roomHeight = Random.Range(_minRoomHeight, _minBlockHeight + roomHeightSpread + 1);
				}
				y = Random.Range(_rooms[i].GetMakeRoomPosY(), _rooms[i].GetMakeRoomPosY() + _minBlockHeight + roomHeightSpread - roomHeight + 1);
			}
			_rooms[i].CreateRoom(x, y, roomWidth, roomHeight);
		}
	}

	//
	public void MakeWall()
	{
		int room = 0;

		//
		for (int i = 1; i < _mapHeight - 1; i++)
		{
			//
			for (int j = 1; j < _mapWidth - 1; j++)
			{
				//
				if (_map[i, j])
				{
					//
					for (room = 0; room < _currentRooms; room++)
					{
						if (_rooms[room].GetRoomArea(j, i))
						{
							break;
						}
					}
					if (room == _currentRooms)
					{
						_map[i, j] = false;
					}
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

//
public class RoomState
{
	public int _makeRoomPosX;
	public int _makeRoomPosY;
	public int _roomWidth;
	public int _roomHeight;

	public void SetPosition(int x, int y)
	{
		_makeRoomPosX = x;
		_makeRoomPosY = y;
	}

	public int GetMakeRoomPosX()
	{
		return _makeRoomPosX;
	}

	public int GetMakeRoomPosY()
	{
		return _makeRoomPosY;
	}

	public int GetMakeRoomWidth()
	{
		return _roomWidth;
	}

	public int GetMakeRoomHeight()
	{
		return _roomHeight;
	}

	public void CreateRoom(int x, int y, int width, int height)
	{
		_makeRoomPosX = x;
		_makeRoomPosY = y;
		_roomWidth = width;
		_roomHeight = height;
	}

	public bool GetRoomArea(int x, int y)
	{
		if (x >= _makeRoomPosX && x < _makeRoomPosX + _roomWidth)
		{
			if (y >= _makeRoomPosY && y < _makeRoomPosY + _roomHeight)
			{
				return true;
			}
		}
		return false;
	}
}
