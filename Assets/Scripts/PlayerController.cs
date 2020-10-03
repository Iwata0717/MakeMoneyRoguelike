using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterState
{
	private CameraController _cameraController = null;
	private TurnManager _turnManager = null;
	private MiniMapManager _miniMapManager = null;

	// Start is called before the first frame update
	void Start()
	{
		_turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
		_dungeonManager = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
		_cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
		_miniMapManager = GameObject.Find("MiniMapManager").GetComponent<MiniMapManager>();
		_cameraController.MoveCamera(transform.position.x, transform.position.y);
		_cameraController.transform.SetParent(this.transform);
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
				while (true)
				{

					//右上
					if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
					{
						if (_dungeonManager.GetMap((int)transform.position.x + 1, (int)transform.position.y + 1))
						{
							_miniMapManager.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x + 1, (int)transform.position.y + 1);
							StartCharacterMove(1, 1, DIR.RIGHTUP);
							_turnManager.ChangeIsPlayerTurn();
							break;
						}
						else
						{
							//break;
						}
					}

					//右下 
					if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
					{
						if (_dungeonManager.GetMap((int)transform.position.x + 1, (int)transform.position.y - 1))
						{
							_miniMapManager.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x + 1, (int)transform.position.y - 1);
							StartCharacterMove(1, -1, DIR.RIGHTDOWN);
							_turnManager.ChangeIsPlayerTurn();
							break;
						}
						else
						{
							//break;
						}
					}

					//左上
					if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
					{
						if (_dungeonManager.GetMap((int)transform.position.x - 1, (int)transform.position.y + 1))
						{
							_miniMapManager.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x - 1, (int)transform.position.y + 1);
							StartCharacterMove(-1, 1, DIR.LEFTUP);
							_turnManager.ChangeIsPlayerTurn();
							break;
						}
						else
						{
							//break;
						}
					}

					//左下
					if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
					{
						if (_dungeonManager.GetMap((int)transform.position.x - 1, (int)transform.position.y - 1))
						{
							_miniMapManager.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x - 1, (int)transform.position.y - 1);
							StartCharacterMove(-1, -1, DIR.LEFTDOWN);
							_turnManager.ChangeIsPlayerTurn();
							break;
						}
						else
						{
							//break;
						}
					}

					//上
					if (Input.GetKey(KeyCode.UpArrow) && _dungeonManager.GetMap((int)transform.position.x, (int)transform.position.y + 1))
					{
						_miniMapManager.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x, (int)transform.position.y + 1);
						StartCharacterMove(0, 1, DIR.UP);
						_turnManager.ChangeIsPlayerTurn();
						break;
					}

					//下
					if (Input.GetKey(KeyCode.DownArrow) && _dungeonManager.GetMap((int)transform.position.x, (int)transform.position.y - 1))
					{
						_miniMapManager.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x, (int)transform.position.y - 1);
						StartCharacterMove(0, -1, DIR.DOWN);
						_turnManager.ChangeIsPlayerTurn();
						break;
					}

					//右
					if (Input.GetKey(KeyCode.RightArrow) && _dungeonManager.GetMap((int)transform.position.x + 1, (int)transform.position.y))
					{
						_miniMapManager.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x + 1, (int)transform.position.y);
						StartCharacterMove(1, 0, DIR.RIGHT);
						_turnManager.ChangeIsPlayerTurn();
						break;
					}

					//左
					if (Input.GetKey(KeyCode.LeftArrow) && _dungeonManager.GetMap((int)transform.position.x - 1, (int)transform.position.y))
					{
						_miniMapManager.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x - 1, (int)transform.position.y);
						StartCharacterMove(-1, 0, DIR.LEFT);
						_turnManager.ChangeIsPlayerTurn();
						break;
					}
					break;
				}
			}
		}
	}
}
