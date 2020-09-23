using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterState
{
	public bool _isLoop = true;
	private DungeonManager _dungeonManager = null;
	
	//
	void Start()
	{
		_dungeonManager = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
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
				_dir = (DIR)Random.Range(0, 4);

				//
				switch (_dir)
				{
					case DIR.UP:

						//
						if (_dungeonManager.GetRoom((int)transform.position.x, -((int)transform.position.y + 1)))
						{
							_dungeonManager.SetRoom((int)transform.position.x, -((int)transform.position.y));
							_dungeonManager.SetRoom((int)transform.position.x, -((int)transform.position.y + 1));
							transform.Translate(0, 1, 0);
							_isLoop = false;
						}
						break;

					case DIR.DOWN:

						//
						if (_dungeonManager.GetRoom((int)transform.position.x, -((int)transform.position.y - 1)))
						{
							_dungeonManager.SetRoom((int)transform.position.x, -(int)transform.position.y);
							_dungeonManager.SetRoom((int)transform.position.x, -((int)transform.position.y - 1));
							transform.Translate(0, -1, 0);
							_isLoop = false;
						}
						break;

					case DIR.RIGHT:

						//
						if (_dungeonManager.GetRoom((int)transform.position.x + 1, -(int)transform.position.y))
						{
							_dungeonManager.SetRoom((int)transform.position.x, -(int)transform.position.y);
							_dungeonManager.SetRoom((int)transform.position.x + 1, -((int)transform.position.y));
							transform.Translate(1, 0, 0);
							_isLoop = false;
						}
						break;

					case DIR.LEFT:

						//
						if (_dungeonManager.GetRoom((int)transform.position.x - 1, -(int)transform.position.y))
						{
							_dungeonManager.SetRoom((int)transform.position.x, -(int)transform.position.y);
							_dungeonManager.SetRoom((int)transform.position.x - 1, -(int)transform.position.y);
							transform.Translate(-1, 0, 0);
							_isLoop = false;
						}
						break;
				}
			}
			_isLoop = true;
		}
	}
}
