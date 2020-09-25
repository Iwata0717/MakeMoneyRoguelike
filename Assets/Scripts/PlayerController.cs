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
				//
				while (true)
				{
					//
					if (Input.GetKey(KeyCode.UpArrow) && _dungeonManager.GetRoom((int)transform.position.x, -((int)transform.position.y + 1)))
					{
						StartCharacterMove(0, 1, DIR.UP);
						_turnManager.ChangeIsPlayerTurn();
						break;
					}

					//
					if (Input.GetKey(KeyCode.DownArrow) && _dungeonManager.GetRoom((int)transform.position.x, -((int)transform.position.y - 1)))
					{
						StartCharacterMove(0, -1, DIR.DOWN);
						_turnManager.ChangeIsPlayerTurn();
						break;
					}

					//
					if (Input.GetKey(KeyCode.RightArrow) && _dungeonManager.GetRoom((int)transform.position.x + 1, -(int)transform.position.y))
					{
						StartCharacterMove(1, 0, DIR.RIGHT);
						_turnManager.ChangeIsPlayerTurn();
						break;
					}

					//
					if (Input.GetKey(KeyCode.LeftArrow) && _dungeonManager.GetRoom((int)transform.position.x - 1, -(int)transform.position.y))
					{
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
