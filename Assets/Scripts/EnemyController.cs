using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterState
{
	public bool _isLoop = true;

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
		if (_dungeonManager.GetRoom((int)transform.position.x, -((int)transform.position.y + 1)) ||
			_dungeonManager.GetRoom((int)transform.position.x, -((int)transform.position.y - 1)) ||
			_dungeonManager.GetRoom((int)transform.position.x + 1, -(int)transform.position.y) ||
			_dungeonManager.GetRoom((int)transform.position.x - 1, -(int)transform.position.y))
		{
			while (_isLoop)
			{
				DIR dir = (DIR)Random.Range(0, 4);

				//
				switch (dir)
				{
					case DIR.UP:

						//
						if (_dungeonManager.GetRoom((int)transform.position.x, -((int)transform.position.y + 1)))
						{
							StartCharacterMove(0, 1, dir);
							_isLoop = false;
						}
						break;

					case DIR.DOWN:

						//
						if (_dungeonManager.GetRoom((int)transform.position.x, -((int)transform.position.y - 1)))
						{
							StartCharacterMove(0, -1, dir);
							_isLoop = false;
						}
						break;

					case DIR.RIGHT:

						//
						if (_dungeonManager.GetRoom((int)transform.position.x + 1, -(int)transform.position.y))
						{
							StartCharacterMove(1, 0, dir);
							_isLoop = false;
						}
						break;

					case DIR.LEFT:

						//
						if (_dungeonManager.GetRoom((int)transform.position.x - 1, -(int)transform.position.y))
						{
							StartCharacterMove(-1, 0, dir);
							_isLoop = false;
						}
						break;
				}
			}
			_isLoop = true;
		}
	}
}
