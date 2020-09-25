using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : TypeManager
{
	protected bool _isMove;
	protected int _hp;
	protected int _attack;
	protected int _defense;
	protected int _movementX, _movementY;
	protected int _targetPosX, _targetPosY;
	protected float _speed = SpeedManager._dash;
	protected enum DIR
	{
		UP,
		DOWN,
		RIGHT,
		RIGHTUP,
		RIGHTDOWN,
		LEFT,
		LEFTUP,
		LEFTDOWN
	}
	[SerializeField] protected DIR _dir;
	protected DungeonManager _dungeonManager = null;

	//
	protected void StartCharacterMove(int movementX, int movementY, DIR dir)
	{
		_isMove = true;
		_movementX = movementX;
		_movementY = movementY;
		_targetPosX = (int)transform.position.x + _movementX;
		_targetPosY = (int)transform.position.y + _movementY;
		_dir = dir;

		_dungeonManager.SetMap((int)transform.position.x, -(int)transform.position.y);
		_dungeonManager.SetMap(_targetPosX, -_targetPosY);
		CharacterMove();
	}

	//
	protected void CharacterMove()
	{
		transform.Translate(_movementX * _speed * Time.deltaTime, _movementY * _speed * Time.deltaTime, 0);

		switch (_dir)
		{
			case DIR.UP:

				if (transform.position.y >= _targetPosY)
				{
					transform.position = new Vector2(transform.position.x, _targetPosY);
					MoveStateReset();
					_isMove = false;
				}
				break;

			case DIR.DOWN:

				if (transform.position.y <= _targetPosY)
				{
					transform.position = new Vector2(transform.position.x, _targetPosY);
					MoveStateReset();
					_isMove = false;
				}
				break;

			case DIR.RIGHT:

				if (transform.position.x >= _targetPosX)
				{
					transform.position = new Vector2(_targetPosX, transform.position.y);
					MoveStateReset();
					_isMove = false;
				}
				break;

			case DIR.RIGHTUP:

				if (transform.position.x >= _targetPosX && transform.position.y >= _targetPosY)
				{
					transform.position = new Vector2(_targetPosX, _targetPosY);
					MoveStateReset();
					_isMove = false;
				}
				break;

			case DIR.RIGHTDOWN:

				if (transform.position.x >= _targetPosX && transform.position.y <= _targetPosY)
				{
					transform.position = new Vector2(_targetPosX, _targetPosY);
					MoveStateReset();
					_isMove = false;
				}
				break;

			case DIR.LEFT:

				if (transform.position.x <= _targetPosX)
				{
					transform.position = new Vector2(_targetPosX, transform.position.y);
					MoveStateReset();
					_isMove = false;
				}
				break;

			case DIR.LEFTUP:

				if (transform.position.x <= _targetPosX && transform.position.y >= _targetPosY)
				{
					transform.position = new Vector2(_targetPosX, _targetPosY);
					MoveStateReset();
					_isMove = false;
				}
				break;

			case DIR.LEFTDOWN:

				if (transform.position.x <= _targetPosX && transform.position.y <= _targetPosY)
				{
					transform.position = new Vector2(_targetPosX, _targetPosY);
					MoveStateReset();
					_isMove = false;
				}
				break;

		}
	}

	public void MoveStateReset()
	{
		_movementX = 0;
		_movementY = 0;
		_targetPosX = 0;
		_targetPosY = 0;
	}
}

public class SpeedManager
{
	public const float _dash = 10f;
	public const float _fast = 5f;
	public const float _normal = 4f;
	public const float _slow = 3f;
}