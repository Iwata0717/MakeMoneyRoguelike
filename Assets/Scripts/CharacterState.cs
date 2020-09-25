using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
	protected bool _isMove;
	protected int _hp;
	protected int _attack;
	protected int _defense;
	protected int _movementX, _movementY;
	protected int _targetPosX, _targetPosY;
	protected float _speed = 4f;
	protected enum DIR
	{
		UP,
		DOWN,
		RIGHT,
		//RIGHTUP,
		//RIGHTDOWN,
		LEFT,
		//LEFTUP,
		//LEFTDOWN
	}
	protected DIR _dir;
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

		_dungeonManager.SetRoom((int)transform.position.x, -(int)transform.position.y);
		_dungeonManager.SetRoom(_targetPosX, -_targetPosY);
		CharacterMove();
	}

	protected void CharacterMove()
	{
		transform.Translate(_movementX * _speed * Time.deltaTime, _movementY * _speed * Time.deltaTime, 0);

		switch (_dir)
		{
			case DIR.UP:

				if (transform.position.y >= _targetPosY)
				{
					transform.position = new Vector2(transform.position.x, _targetPosY);
					_isMove = false;
				}
				break;

			case DIR.DOWN:

				if (transform.position.y <= _targetPosY)
				{
					transform.position = new Vector2(transform.position.x, _targetPosY);
					_isMove = false;
				}
				break;

			case DIR.RIGHT:

				if (transform.position.x >= _targetPosX)
				{
					transform.position = new Vector2(_targetPosX, transform.position.y);
					_isMove = false;
				}
				break;

			case DIR.LEFT:

				if (transform.position.x <= _targetPosX)
				{
					transform.position = new Vector2(_targetPosX, transform.position.y);
					_isMove = false;
				}
				break;
		}
	}
}