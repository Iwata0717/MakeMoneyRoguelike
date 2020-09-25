using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterState
{
	private CameraController _cameraController = null;
	private TurnManager _turnManager = null;

	// Start is called before the first frame update
	void Start()
	{
		_turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
		_dungeonManager = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
		_cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
		_cameraController.MoveCamera(transform.position.x, transform.position.y);
		_cameraController.transform.parent = this.transform;
	}

	// Update is called once per frame
	void Update()
	{
		//移動中だったら
		if (_isMove)
		{
			CharacterMove();
		}

		//移動中でなければ
		else
		{
			//プレイヤーのターンだったら行動
			if (_turnManager.GetIsPlayerTurn())
			{
				int x = 0;
				int y = 0;
				DIR dir = DIR.UP;

				//上
				if (Input.GetKey(KeyCode.UpArrow) && _dungeonManager.GetMap((int)transform.position.x, -(int)transform.position.y - 1))
				{
					x = 0;
					y = 1;
					dir = DIR.UP;
				}

				//下
				else if (Input.GetKey(KeyCode.DownArrow) && _dungeonManager.GetMap((int)transform.position.x, -(int)transform.position.y + 1))
				{
					x = 0;
					y = -1;
					dir = DIR.DOWN;
				}

				//右
				else if (Input.GetKey(KeyCode.RightArrow) && _dungeonManager.GetMap((int)transform.position.x + 1, -(int)transform.position.y))
				{
					x = 1;
					y = 0;
					dir = DIR.RIGHT;
				}

				//左
				else if (Input.GetKey(KeyCode.LeftArrow) && _dungeonManager.GetMap((int)transform.position.x - 1, -(int)transform.position.y))
				{
					x = -1;
					y = 0;
					dir = DIR.LEFT;
				}

				//右上
				if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
				{
					if (_dungeonManager.GetMap((int)transform.position.x + 1, -(int)transform.position.y - 1))
					{
						x = 1;
						y = 1;
						dir = DIR.RIGHTUP;
					}
					else
					{
						x = 0;
						y = 0;
					}
				}

				//右下 
				else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
				{
					if (_dungeonManager.GetMap((int)transform.position.x + 1, -(int)transform.position.y + 1))
					{
						x = 1;
						y = -1;
						dir = DIR.RIGHTDOWN;
					}
					else
					{
						x = 0;
						y = 0;
					}
				}

				//左上
				else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
				{
					if (_dungeonManager.GetMap((int)transform.position.x - 1, -(int)transform.position.y - 1))
					{
						x = -1;
						y = 1;
						dir = DIR.LEFTUP;
					}
					else
					{
						x = 0;
						y = 0;
					}
				}

				//左下
				else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
				{
					if (_dungeonManager.GetMap((int)transform.position.x - 1, -(int)transform.position.y + 1))
					{
						x = -1;
						y = -1;
						dir = DIR.LEFTDOWN;
					}
					else
					{
						x = 0;
						y = 0;
					}
				}
				if (x != 0 || y != 0)
				{
					StartCharacterMove(x, y, dir);
					_turnManager.ChangeIsPlayerTurn();
				}
			}
		}
	}
}
