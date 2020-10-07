using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterState
{
	private bool _isLoop = true;
	
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
		if (Managers.Dungeon.GetMap((int)transform.position.x, (int)transform.position.y + 1) ||
			Managers.Dungeon.GetMap((int)transform.position.x, (int)transform.position.y - 1) ||
			Managers.Dungeon.GetMap((int)transform.position.x + 1, (int)transform.position.y) ||
			Managers.Dungeon.GetMap((int)transform.position.x - 1, (int)transform.position.y) ||
			Managers.Dungeon.GetMap((int)transform.position.x + 1, (int)transform.position.y + 1) ||
			Managers.Dungeon.GetMap((int)transform.position.x + 1, (int)transform.position.y - 1) ||
			Managers.Dungeon.GetMap((int)transform.position.x - 1, (int)transform.position.y + 1) ||
			Managers.Dungeon.GetMap((int)transform.position.x - 1, (int)transform.position.y - 1) ||
			Managers.CharacterCollider.GetCollider((int)transform.position.x, (int)transform.position.y + 1) ||
			Managers.CharacterCollider.GetCollider((int)transform.position.x, (int)transform.position.y - 1) ||
			Managers.CharacterCollider.GetCollider((int)transform.position.x + 1, (int)transform.position.y) ||
			Managers.CharacterCollider.GetCollider((int)transform.position.x - 1, (int)transform.position.y) ||
			Managers.CharacterCollider.GetCollider((int)transform.position.x + 1, (int)transform.position.y + 1) ||
			Managers.CharacterCollider.GetCollider((int)transform.position.x + 1, (int)transform.position.y - 1) ||
			Managers.CharacterCollider.GetCollider((int)transform.position.x - 1, (int)transform.position.y + 1) ||
			Managers.CharacterCollider.GetCollider((int)transform.position.x - 1, (int)transform.position.y - 1))
		{
			while (_isLoop)
			{
				DIR dir = (DIR)Random.Range(0, 8);

				//
				switch (dir)
				{
					case DIR.UP:

						//
						if (Managers.Dungeon.GetMap((int)transform.position.x, (int)transform.position.y + 1) &&
							Managers.CharacterCollider.GetCollider((int)transform.position.x, (int)transform.position.y + 1))
						{
							Managers.MiniMap.EnemyMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x, (int)transform.position.y + 1);
							StartCharacterMove(0, 1, dir);
							_isLoop = false;
						}
						break;

					case DIR.DOWN:

						//
						if (Managers.Dungeon.GetMap((int)transform.position.x, (int)transform.position.y - 1) &&
							Managers.CharacterCollider.GetCollider((int)transform.position.x, (int)transform.position.y - 1))
						{
							Managers.MiniMap.EnemyMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x, (int)transform.position.y - 1);
							StartCharacterMove(0, -1, dir);
							_isLoop = false;
						}
						break;

					case DIR.RIGHT:

						//
						if (Managers.Dungeon.GetMap((int)transform.position.x + 1, (int)transform.position.y) &&
							Managers.CharacterCollider.GetCollider((int)transform.position.x + 1, (int)transform.position.y))
						{
							Managers.MiniMap.EnemyMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x + 1, (int)transform.position.y);
							StartCharacterMove(1, 0, dir);
							_isLoop = false;
						}
						break;

					case DIR.RIGHTUP:

						//
						if (Managers.Dungeon.GetMap((int)transform.position.x + 1, (int)transform.position.y + 1) &&
							Managers.CharacterCollider.GetCollider((int)transform.position.x + 1, (int)transform.position.y + 1))
						{
							Managers.MiniMap.EnemyMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x + 1, (int)transform.position.y + 1);
							StartCharacterMove(1, 1, dir);
							_isLoop = false;
						}
						break;

					case DIR.RIGHTDOWN:

						//
						if (Managers.Dungeon.GetMap((int)transform.position.x + 1, (int)transform.position.y - 1) &&
							Managers.CharacterCollider.GetCollider((int)transform.position.x + 1, (int)transform.position.y - 1))
						{
							Managers.MiniMap.EnemyMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x + 1, (int)transform.position.y - 1);
							StartCharacterMove(1, -1, dir);
							_isLoop = false;
						}
						break;

					case DIR.LEFT:

						//
						if (Managers.Dungeon.GetMap((int)transform.position.x - 1, (int)transform.position.y) &&
							Managers.CharacterCollider.GetCollider((int)transform.position.x - 1, (int)transform.position.y))
						{
							Managers.MiniMap.EnemyMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x - 1, (int)transform.position.y);
							StartCharacterMove(-1, 0, dir);
							_isLoop = false;
						}
						break;

					case DIR.LEFTUP:

						//
						if (Managers.Dungeon.GetMap((int)transform.position.x - 1, (int)transform.position.y + 1) &&
							Managers.CharacterCollider.GetCollider((int)transform.position.x - 1, (int)transform.position.y + 1))
						{
							Managers.MiniMap.EnemyMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x - 1, (int)transform.position.y + 1);
							StartCharacterMove(-1, 1, dir);
							_isLoop = false;
						}
						break;

					case DIR.LEFTDOWN:

						//
						if (Managers.Dungeon.GetMap((int)transform.position.x - 1, (int)transform.position.y - 1) &&
							Managers.CharacterCollider.GetCollider((int)transform.position.x - 1, (int)transform.position.y - 1))
						{
							Managers.MiniMap.EnemyMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x - 1, (int)transform.position.y - 1);
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
