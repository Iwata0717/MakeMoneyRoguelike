using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterState
{
	private bool _isLoop = true;

	//
	void Start()
	{
		_dungeonManager = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
	}

	void Update()
	{
		//移動中だったら
		if (_isMove)
		{
			CharacterMove();
		}
	}

	public void MoveEnemy()
	{
		//
		if (_dungeonManager.GetMap((int)transform.position.x, -((int)transform.position.y + 1)) ||
			_dungeonManager.GetMap((int)transform.position.x, -((int)transform.position.y - 1)) ||
			_dungeonManager.GetMap((int)transform.position.x + 1, -(int)transform.position.y) ||
			_dungeonManager.GetMap((int)transform.position.x - 1, -(int)transform.position.y) ||
			_dungeonManager.GetMap((int)transform.position.x + 1, -((int)transform.position.y + 1)) ||
			_dungeonManager.GetMap((int)transform.position.x + 1, -((int)transform.position.y - 1)) ||
			_dungeonManager.GetMap((int)transform.position.x - 1, -(int)transform.position.y + 1) ||
			_dungeonManager.GetMap((int)transform.position.x - 1, -(int)transform.position.y - 1))
		{
			while (_isLoop)
			{
				DIR dir = (DIR)Random.Range(0, 8);

				//
				switch (dir)
				{
					case DIR.UP:

						//
						if (_dungeonManager.GetMap((int)transform.position.x, -(int)transform.position.y - 1))
						{
							StartCharacterMove(0, 1, dir);
							_isLoop = false;
						}
						break;

					case DIR.DOWN:

						//
						if (_dungeonManager.GetMap((int)transform.position.x, -(int)transform.position.y + 1))
						{
							StartCharacterMove(0, -1, dir);
							_isLoop = false;
						}
						break;

					case DIR.RIGHT:

						//
						if (_dungeonManager.GetMap((int)transform.position.x + 1, -(int)transform.position.y))
						{
							StartCharacterMove(1, 0, dir);
							_isLoop = false;
						}
						break;

					case DIR.RIGHTUP:

						//
						if (_dungeonManager.GetMap((int)transform.position.x + 1, -(int)transform.position.y - 1))
						{
							StartCharacterMove(1, 1, dir);
							_isLoop = false;
						}
						break;

					case DIR.RIGHTDOWN:

						//
						if (_dungeonManager.GetMap((int)transform.position.x + 1, -(int)transform.position.y + 1))
						{
							StartCharacterMove(1, -1, dir);
							_isLoop = false;
						}
						break;

					case DIR.LEFT:

						//
						if (_dungeonManager.GetMap((int)transform.position.x - 1, -(int)transform.position.y))
						{
							StartCharacterMove(-1, 0, dir);
							_isLoop = false;
						}
						break;

					case DIR.LEFTUP:

						//
						if (_dungeonManager.GetMap((int)transform.position.x - 1, -(int)transform.position.y - 1))
						{
							StartCharacterMove(-1, 1, dir);
							_isLoop = false;
						}
						break;

					case DIR.LEFTDOWN:

						//
						if (_dungeonManager.GetMap((int)transform.position.x - 1, -(int)transform.position.y + 1))
						{
							StartCharacterMove(-1, -1, dir);
							_isLoop = false;
						}
						break;
				}
			}
			_isLoop = true;
		}
	}
}
