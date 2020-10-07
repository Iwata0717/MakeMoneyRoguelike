using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : StatesBase
{
	private const int _mapWidth = 50;
	private const int _mapHeight = 30;

	private static int _maxRooms = 10;
	private int _currentRooms = 0;

	private const int _minRoomWidth = 8;
	private const int _maxRoomWidth = 20;
	private const int _minRoomHeight = 8;
	private const int _maxRoomHeight = 20;

	private int _minBlockWidth;
	private int _minBlockHeight;

	private static bool[,] _map = new bool[_mapHeight, _mapWidth];
	private static bool[,] _mapRoad = new bool[_mapHeight, _mapWidth];
	private State[] _blocks = new State[_maxRooms];
	private State[] _rooms = new State[_maxRooms];

	[SerializeField] private SpriteRenderer Floor = null;
	//[SerializeField] private SpriteRenderer Wall = null;
	[SerializeField] private SpriteRenderer Room = null;
	[SerializeField] private SpriteRenderer BackGround = null;

	//
	public override void OnStart()
	{
		//
		_minBlockWidth = _minRoomWidth + 2;
		_minBlockHeight = _minRoomHeight + 2;

		//
		for (int i = 0; i < _maxRooms; i++)
		{
			_blocks[i] = new State();
			_rooms[i] = new State();
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

				//
				_mapRoad[i, j] = false;
			}
		}

		MakeBackGround();
		MakeLine();
		CreateRooms();
		CheckRoomNextDoors();
		MakeWall();
		MakeRoad();
	}

	//
	public override void OnUpdate()
	{

	}

	//
	public void MakeLine()
	{
		bool isNextRoom = true;
		int line;

		_blocks[_currentRooms].PosX = 1;
		_blocks[_currentRooms].PosY = 1;
		_currentRooms++;

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
							_blocks[_currentRooms].PosX = line + 1;
							_blocks[_currentRooms].PosY = 1;
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
									_blocks[_currentRooms].PosX = line + 1;
									_blocks[_currentRooms].PosY = j + 1;
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
									_blocks[_currentRooms].PosX = j + 1;
									_blocks[_currentRooms].PosY = line + 1;
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
							_blocks[_currentRooms].PosX = 1;
							_blocks[_currentRooms].PosY = line + 1;
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

	//
	public void CreateRooms()
	{
		for (int i = 0; i < _currentRooms; i++)
		{
			int roomWidthSpread = 0;
			int roomHeightSpread = 0;

			//
			while (_map[_blocks[i].PosY, _blocks[i].PosX + _minBlockWidth - 1 + roomWidthSpread])
			{
				roomWidthSpread++;
			}
			roomWidthSpread--;
			_blocks[i].Width = _minBlockWidth + roomWidthSpread;

			if (_blocks[i].Width - 2 > _maxRoomWidth)
			{
				_rooms[i].Width = Random.Range(_minRoomWidth, _maxRoomWidth + 1);
			}
			else
			{
				_rooms[i].Width = Random.Range(_minRoomWidth, _blocks[i].Width - 2 + 1);
			}
			_rooms[i].PosX = Random.Range(_blocks[i].PosX + 1, _blocks[i].PosX + _blocks[i].Width - _rooms[i].Width);

			//
			while (_map[_blocks[i].PosY + _minBlockHeight - 1 + roomHeightSpread, _blocks[i].PosX])
			{
				roomHeightSpread++;
			}
			roomHeightSpread--;
			_blocks[i].Height = _minBlockHeight + roomHeightSpread;

			if (_blocks[i].Height - 2 > _maxRoomHeight)
			{
				_rooms[i].Height = Random.Range(_minRoomHeight, _maxRoomHeight + 1);
			}
			else
			{
				_rooms[i].Height = Random.Range(_minRoomHeight, _blocks[i].Height - 2 + 1);
			}
			_rooms[i].PosY = Random.Range(_blocks[i].PosY + 1, _blocks[i].PosY + _blocks[i].Height - _rooms[i].Height);

			//
			Room.size = new Vector2(_rooms[i].Width, _rooms[i].Height);
			Instantiate(Room, new Vector3(_rooms[i].PosX + (_rooms[i].Width - 1) * 0.5f, _rooms[i].PosY + (_rooms[i].Height - 1) * 0.5f), Quaternion.identity);
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
	public void CheckRoomNextDoors()
	{
		for (int i = 0; i < _currentRooms; i++)
		{
			for (int j = i + 1; j < _currentRooms; j++)
			{
				//右隣だったら
				if (_blocks[i].PosX + _blocks[i].Width + 1 == _blocks[j].PosX)
				{
					if (_blocks[i].PosY == _blocks[j].PosY || _blocks[i].PosY + _blocks[i].Height - 1 == _blocks[j].PosY + _blocks[j].Height - 1)
					{
						int startPosX;
						int startPosY1;
						int startPosY2;

						startPosX = _rooms[i].PosX + _rooms[i].Width;
						if (_blocks[i].PosY == _blocks[j].PosY)
						{
							startPosY1 = Random.Range(_rooms[i].PosY, _rooms[i].PosY + _rooms[i].Height / 2);
						}
						else
						{
							startPosY1 = Random.Range(_rooms[i].PosY + _rooms[i].Height / 2, _rooms[i].PosY + _rooms[i].Height);
						}

						while (_map[startPosY1, startPosX])
						{
							_mapRoad[startPosY1, startPosX] = true;
							Instantiate(Floor, new Vector3(startPosX, startPosY1), Quaternion.identity);
							startPosX++;
						}

						startPosX = _rooms[j].PosX - 1;
						if (_blocks[i].PosY == _blocks[j].PosY)
						{
							startPosY2 = Random.Range(_rooms[j].PosY, _rooms[j].PosY + _rooms[j].Height / 2);
						}
						else
						{
							startPosY2 = Random.Range(_rooms[j].PosY + _rooms[j].Height / 2, _rooms[j].PosY + _rooms[j].Height);
						}

						while (_map[startPosY2, startPosX])
						{
							_mapRoad[startPosY2, startPosX] = true;
							Instantiate(Floor, new Vector3(startPosX, startPosY2), Quaternion.identity);
							startPosX--;
						}

						while (true)
						{
							if (startPosY1 > startPosY2)
							{
								if (!_mapRoad[startPosY1, startPosX])
								{
									_mapRoad[startPosY1, startPosX] = true;
									Instantiate(Floor, new Vector3(startPosX, startPosY1), Quaternion.identity);
								}
								startPosY1--;
							}
							else if (startPosY1 < startPosY2)
							{
								if (!_mapRoad[startPosY2, startPosX])
								{
									_mapRoad[startPosY2, startPosX] = true;
									Instantiate(Floor, new Vector3(startPosX, startPosY2), Quaternion.identity);
								}
								startPosY2--;
							}
							else if (startPosY1 == startPosY2)
							{
								_mapRoad[startPosY1, startPosX] = true;
								Instantiate(Floor, new Vector3(startPosX, startPosY1), Quaternion.identity);
								break;
							}
						}
					}
				}

				//左隣だったら
				if (_blocks[i].PosX - 2 == _blocks[j].PosX + _blocks[j].Width - 1)
				{
					if (_blocks[i].PosY == _blocks[j].PosY || _blocks[i].PosY + _blocks[i].Height - 1 == _blocks[j].PosY + _blocks[j].Height - 1)
					{
						int startPosX;
						int startPosY1;
						int startPosY2;

						startPosX = _rooms[i].PosX - 1;
						if (_blocks[i].PosY == _blocks[j].PosY)
						{
							startPosY1 = Random.Range(_rooms[i].PosY, _rooms[i].PosY + _rooms[i].Height / 2);
						}
						else
						{
							startPosY1 = Random.Range(_rooms[i].PosY + _rooms[i].Height / 2, _rooms[i].PosY + _rooms[i].Height);
						}

						while (_map[startPosY1, startPosX])
						{
							_mapRoad[startPosY1, startPosX] = true;
							Instantiate(Floor, new Vector3(startPosX, startPosY1), Quaternion.identity);
							startPosX--;
						}

						startPosX = _rooms[j].PosX + _rooms[j].Width;
						if (_blocks[i].PosY == _blocks[j].PosY)
						{
							startPosY2 = Random.Range(_rooms[j].PosY, _rooms[j].PosY + _rooms[j].Height / 2);
						}
						else
						{
							startPosY2 = Random.Range(_rooms[j].PosY + _rooms[j].Height / 2, _rooms[j].PosY + _rooms[j].Height);
						}

						while (_map[startPosY2, startPosX])
						{
							_mapRoad[startPosY2, startPosX] = true;
							Instantiate(Floor, new Vector3(startPosX, startPosY2), Quaternion.identity);
							startPosX++;
						}

						while (true)
						{
							if (startPosY1 > startPosY2)
							{
								if (!_mapRoad[startPosY1, startPosX])
								{
									_mapRoad[startPosY1, startPosX] = true;
									Instantiate(Floor, new Vector3(startPosX, startPosY1), Quaternion.identity);
								}
								startPosY1--;
							}
							else if (startPosY1 < startPosY2)
							{
								if (!_mapRoad[startPosY2, startPosX])
								{
									_mapRoad[startPosY2, startPosX] = true;
									Instantiate(Floor, new Vector3(startPosX, startPosY2), Quaternion.identity);
								}
								startPosY2--;
							}
							else if (startPosY1 == startPosY2)
							{
								_mapRoad[startPosY1, startPosX] = true;
								Instantiate(Floor, new Vector3(startPosX, startPosY1), Quaternion.identity);
								break;
							}
						}
					}
				}

				//上隣だったら
				if (_blocks[i].PosY - 2 == _blocks[j].PosY + _blocks[j].Height - 1)
				{
					if (_blocks[i].PosX == _blocks[j].PosX || _blocks[i].PosX + _blocks[i].Width - 1 == _blocks[j].PosX + _blocks[j].Width - 1)
					{
						int startPosX1;
						int startPosX2;
						int startPosY;

						if (_blocks[i].PosX == _blocks[j].PosX)
						{
							startPosX1 = Random.Range(_rooms[i].PosX, _rooms[i].PosX + _rooms[i].Width / 2);
						}
						else
						{
							startPosX1 = Random.Range(_rooms[i].PosX + _rooms[i].Width / 2, _rooms[i].PosX + _rooms[i].Width);
						}
						startPosY = _rooms[i].PosY - 1;

						while (_map[startPosY, startPosX1])
						{
							_mapRoad[startPosY, startPosX1] = true;
							Instantiate(Floor, new Vector3(startPosX1, startPosY), Quaternion.identity);
							startPosY--;
						}

						if (_blocks[i].PosX == _blocks[j].PosX)
						{
							startPosX2 = Random.Range(_rooms[j].PosX, _rooms[j].PosX + _rooms[j].Width / 2);
						}
						else
						{
							startPosX2 = Random.Range(_rooms[j].PosX + _rooms[j].Width / 2, _rooms[j].PosX + _rooms[j].Width);
						}
						startPosY = _rooms[j].PosY + _rooms[j].Height;

						while (_map[startPosY, startPosX2])
						{
							_mapRoad[startPosY, startPosX2] = true;
							Instantiate(Floor, new Vector3(startPosX2, startPosY), Quaternion.identity);
							startPosY++;
						}

						while (true)
						{
							if (startPosX1 > startPosX2)
							{
								if (!_mapRoad[startPosY, startPosX1])
								{
									_mapRoad[startPosY, startPosX1] = true;
									Instantiate(Floor, new Vector3(startPosX1, startPosY), Quaternion.identity);
								}
								startPosX1--;
							}
							else if (startPosX1 < startPosX2)
							{
								if (!_mapRoad[startPosY, startPosX2])
								{
									_mapRoad[startPosY, startPosX2] = true;
									Instantiate(Floor, new Vector3(startPosX2, startPosY), Quaternion.identity);
								}
								startPosX2--;
							}
							else if (startPosX1 == startPosX2)
							{
								_mapRoad[startPosY, startPosX1] = true;
								Instantiate(Floor, new Vector3(startPosX1, startPosY), Quaternion.identity);
								break;
							}
						}
					}
				}

				//下隣だったら
				if (_blocks[i].PosY + _blocks[i].Height + 1 == _blocks[j].PosY)
				{
					if (_blocks[i].PosX == _blocks[j].PosX || _blocks[i].PosX + _blocks[i].Width - 1 == _blocks[j].PosX + _blocks[j].Width - 1)
					{
						int startPosX1;
						int startPosX2;
						int startPosY;

						if (_blocks[i].PosX == _blocks[j].PosX)
						{
							startPosX1 = Random.Range(_rooms[i].PosX, _rooms[i].PosX + _rooms[i].Width / 2);
						}
						else
						{
							startPosX1 = Random.Range(_rooms[i].PosX + _rooms[i].Width / 2, _rooms[i].PosX + _rooms[i].Width);
						}
						startPosY = _rooms[i].PosY + _rooms[i].Height;

						while (_map[startPosY, startPosX1])
						{
							_mapRoad[startPosY, startPosX1] = true;
							Instantiate(Floor, new Vector3(startPosX1, startPosY), Quaternion.identity);
							startPosY++;
						}

						if (_blocks[i].PosX == _blocks[j].PosX)
						{
							startPosX2 = Random.Range(_rooms[j].PosX, _rooms[j].PosX + _rooms[j].Width / 2);
						}
						else
						{
							startPosX2 = Random.Range(_rooms[j].PosX + _rooms[j].Width / 2, _rooms[j].PosX + _rooms[j].Width);
						}
						startPosY = _rooms[j].PosY - 1;

						while (_map[startPosY, startPosX2])
						{
							_mapRoad[startPosY, startPosX2] = true;
							Instantiate(Floor, new Vector3(startPosX2, startPosY), Quaternion.identity);
							startPosY--;
						}

						while (true)
						{
							if (startPosX1 > startPosX2)
							{
								if (!_mapRoad[startPosY, startPosX1])
								{
									_mapRoad[startPosY, startPosX1] = true;
									Instantiate(Floor, new Vector3(startPosX1, startPosY), Quaternion.identity);
								}
								startPosX1--;
							}
							else if (startPosX1 < startPosX2)
							{
								if (!_mapRoad[startPosY, startPosX2])
								{
									_mapRoad[startPosY, startPosX2] = true;
									Instantiate(Floor, new Vector3(startPosX2, startPosY), Quaternion.identity);
								}
								startPosX2--;
							}
							else if(startPosX1 == startPosX2)
							{
								_mapRoad[startPosY, startPosX1] = true;
								Instantiate(Floor, new Vector3(startPosX1, startPosY), Quaternion.identity);
								break;
							}
						}
					}
				}
			}
		}
	}

	//
	public void MakeRoad()
	{
		for (int i = 1; i < _mapHeight - 1; i++)
		{
			for (int j = 1; j < _mapWidth - 1; j++)
			{
				//
				if (_mapRoad[i, j])
				{
					_map[i, j] = true; ;
				}
			}
		}
	}

	//
	public void MakeBackGround()
	{
		BackGround.size = new Vector2(_mapWidth + 10, _mapHeight + 10);
		Instantiate(BackGround, new Vector3((_mapWidth - 1) * 0.5f, (_mapHeight - 1) * 0.5f), Quaternion.identity);
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
	}/*

	//
	public void SetMap(int x, int y)
	{
		_map[y, x] = !_map[y, x];
	}*/
}

//
public class State
{
	//
	private int _posX;
	public int PosX
	{
		get { return _posX; }
		set { _posX = value; }
	}
	private int _posY;
	public int PosY
	{
		get { return _posY; }
		set { _posY = value; }
	}
	private int _width;
	public int Width
	{
		get { return _width; }
		set { _width = value; }
	}
	private int _height;
	public int Height
	{
		get { return _height; }
		set { _height = value; }
	}

	//
	public bool GetRoomArea(int x, int y)
	{
		if (x >= PosX && x < PosX + Width)
		{
			if (y >= PosY && y < PosY + Height)
			{
				return true;
			}
		}
		return false;
	}
}