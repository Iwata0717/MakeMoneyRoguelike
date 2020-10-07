using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterState
{
	private CameraController _cameraController = null;

	// Start is called before the first frame update
	void Start()
	{
		_cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
		_cameraController.MoveCamera(transform.position.x, transform.position.y);
		_cameraController.transform.SetParent(this.transform);
	}

	//
	public void PlayerMove()
	{
		//移動中だったら
		if (_isMove)
		{
			CharacterMove();
		}

		//移動中でなければ
		else
		{
			//
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
			{

			}

			//右上
			else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && 
				Managers.Dungeon.GetMap((int)transform.position.x + 1, (int)transform.position.y + 1) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x + 1, (int)transform.position.y + 1))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x + 1, (int)transform.position.y + 1);
				StartCharacterMove(1, 1, DIR.RIGHTUP);
				Managers.Turn.ChangeIsPlayerTurn();
			}

			//右下 
			else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow) && 
				Managers.Dungeon.GetMap((int)transform.position.x + 1, (int)transform.position.y - 1) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x + 1, (int)transform.position.y - 1))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x + 1, (int)transform.position.y - 1);
				StartCharacterMove(1, -1, DIR.RIGHTDOWN);
				Managers.Turn.ChangeIsPlayerTurn();
			}

			//左上
			else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) &&
				Managers.Dungeon.GetMap((int)transform.position.x - 1, (int)transform.position.y + 1) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x - 1, (int)transform.position.y + 1))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x - 1, (int)transform.position.y + 1);
				StartCharacterMove(-1, 1, DIR.LEFTUP);
				Managers.Turn.ChangeIsPlayerTurn();
			}

			//左下
			else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow) &&
				Managers.Dungeon.GetMap((int)transform.position.x - 1, (int)transform.position.y - 1) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x - 1, (int)transform.position.y - 1))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x - 1, (int)transform.position.y - 1);
				StartCharacterMove(-1, -1, DIR.LEFTDOWN);
				Managers.Turn.ChangeIsPlayerTurn();
			}

			//上
			else if (Input.GetKey(KeyCode.UpArrow) &&
				Managers.Dungeon.GetMap((int)transform.position.x, (int)transform.position.y + 1) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x, (int)transform.position.y + 1))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x, (int)transform.position.y + 1);
				StartCharacterMove(0, 1, DIR.UP);
				Managers.Turn.ChangeIsPlayerTurn();
			}

			//下
			else if (Input.GetKey(KeyCode.DownArrow) &&
				Managers.Dungeon.GetMap((int)transform.position.x, (int)transform.position.y - 1) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x, (int)transform.position.y - 1))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x, (int)transform.position.y - 1);
				StartCharacterMove(0, -1, DIR.DOWN);
				Managers.Turn.ChangeIsPlayerTurn();
			}

			//右
			else if (Input.GetKey(KeyCode.RightArrow) &&
				Managers.Dungeon.GetMap((int)transform.position.x + 1, (int)transform.position.y) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x + 1, (int)transform.position.y))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x + 1, (int)transform.position.y);
				StartCharacterMove(1, 0, DIR.RIGHT);
				Managers.Turn.ChangeIsPlayerTurn();
			}

			//左
			else if (Input.GetKey(KeyCode.LeftArrow) &&
				Managers.Dungeon.GetMap((int)transform.position.x - 1, (int)transform.position.y) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x - 1, (int)transform.position.y))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x - 1, (int)transform.position.y);
				StartCharacterMove(-1, 0, DIR.LEFT);
				Managers.Turn.ChangeIsPlayerTurn();
			}
		}
	}
}
