using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterState
{
	private CameraController _cameraController = null;
	private TurnManager _turnManager = null;
	private DungeonManager _dungeonManager = null;

	// Start is called before the first frame update
	void Start()
	{
		_cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
		_cameraController.MoveCamera(transform.position.x, transform.position.y);
		_turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
		_dungeonManager = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
	}

	// Update is called once per frame
	void Update()
	{
		//プレイヤーのターンだったら行動
		if (_turnManager.GetIsPlayerTurn())
		{
			//
			while (true)
			{
				//
				if (Input.GetKeyUp(KeyCode.UpArrow) && _dungeonManager.GetRoom((int)transform.position.x, -((int)transform.position.y + 1)))
				{
					_dungeonManager.SetRoom((int)transform.position.x, -(int)transform.position.y);
					_dungeonManager.SetRoom((int)transform.position.x, -((int)transform.position.y + 1));
					transform.Translate(0, 1, 0);
					_cameraController.MoveCamera(transform.position.x, transform.position.y);
					_turnManager.ChangeIsPlayerTurn();
					break;
				}

				//
				if (Input.GetKeyUp(KeyCode.DownArrow) && _dungeonManager.GetRoom((int)transform.position.x, -((int)transform.position.y - 1)))
				{
					_dungeonManager.SetRoom((int)transform.position.x, -(int)transform.position.y);
					_dungeonManager.SetRoom((int)transform.position.x, -((int)transform.position.y - 1));
					transform.Translate(0, -1, 0);
					_cameraController.MoveCamera(transform.position.x, transform.position.y);
					_turnManager.ChangeIsPlayerTurn();
					break;
				}

				//
				if (Input.GetKeyUp(KeyCode.RightArrow) && _dungeonManager.GetRoom((int)transform.position.x + 1, -(int)transform.position.y))
				{
					_dungeonManager.SetRoom((int)transform.position.x, -(int)transform.position.y);
					_dungeonManager.SetRoom((int)transform.position.x + 1, -(int)transform.position.y);
					transform.Translate(1, 0, 0);
					_cameraController.MoveCamera(transform.position.x, transform.position.y);
					_turnManager.ChangeIsPlayerTurn();
					break;
				}

				//
				if (Input.GetKeyUp(KeyCode.LeftArrow) && _dungeonManager.GetRoom((int)transform.position.x - 1, -(int)transform.position.y))
				{
					_dungeonManager.SetRoom((int)transform.position.x, -(int)transform.position.y);
					_dungeonManager.SetRoom((int)transform.position.x - 1, -(int)transform.position.y);
					transform.Translate(-1, 0, 0);
					_cameraController.MoveCamera(transform.position.x, transform.position.y);
					_turnManager.ChangeIsPlayerTurn();
					break;
				}
				break;
			}
		}
	}
}
