using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterState
{
	private bool _isLoop = true;

	/// <summary>
	/// Update
	/// </summary>
	private void Update()
	{
		//移動中だったら
		if (_isMove)
		{
			CharacterMove();
		}
	}

	/// <summary>
	/// Inisialize
	/// </summary>
	public void Inisialize()
	{
		CharactorInisialize();
	}

	/// <summary>
	/// ChackAttackArea
	/// </summary>
	/// <returns></returns>
	public bool ChackAttackArea()
	{
		if (Managers.Player.GetPosition() == new Vector3(transform.position.x + 1, transform.position.y, transform.position.z))
		{
			AttackThePlayer("AttackRight");
			return true;
		}
		else if (Managers.Player.GetPosition() == new Vector3(transform.position.x - 1, transform.position.y, transform.position.z))
		{
			AttackThePlayer("AttackLeft");
			return true;
		}
		else if (Managers.Player.GetPosition() == new Vector3(transform.position.x, transform.position.y + 1, transform.position.z))
		{
			AttackThePlayer("AttackUp");
			return true;
		}
		else if (Managers.Player.GetPosition() == new Vector3(transform.position.x, transform.position.y - 1, transform.position.z))
		{
			AttackThePlayer("AttackDown");
			return true;
		}
		else if (Managers.Player.GetPosition() == new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z))
		{
			AttackThePlayer("AttackUpRight");
			return true;
		}
		else if (Managers.Player.GetPosition() == new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.z))
		{
			AttackThePlayer("AttackDownRight");
			return true;
		}
		else if (Managers.Player.GetPosition() == new Vector3(transform.position.x - 1, transform.position.y + 1, transform.position.z))
		{
			AttackThePlayer("AttackUpLeft");
			return true;
		}
		else if (Managers.Player.GetPosition() == new Vector3(transform.position.x - 1, transform.position.y - 1, transform.position.z))
		{
			AttackThePlayer("AttackDownLeft");
			return true;
		}
		return false;
	}

	/// <summary>
	/// AttackThePlayer
	/// </summary>
	/// <returns></returns>
	public void AttackThePlayer(string str)
	{
		_animator.SetTrigger(str);
		Managers.Player.Damage();
	}

	/// <summary>
	/// MoveEnemy
	/// </summary>
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
