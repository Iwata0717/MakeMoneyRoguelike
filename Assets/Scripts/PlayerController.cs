using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterState
{
	[SerializeField] private Sprite _damageSprite = null;

	private SpriteRenderer _spriteRenderer = null;
	private CameraController _cameraController = null;
	private UiHPController _hpText = null;
	private UIWhiteController _uIWhiteController = null;

	/// <summary>
	/// Start
	/// </summary>
	private void Start()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
		_cameraController.MoveCamera(transform.position.x, transform.position.y);
		_cameraController.transform.SetParent(this.transform);
		_hp = 3;
		_hpText = Managers.Player.GetHpText().GetComponent<UiHPController>();
		_uIWhiteController = Managers.Player.GetUIWhiteController().GetComponent<UIWhiteController>();
	}

	/// <summary>
	/// PlayerMove
	/// </summary>
	public void PlayerMove()
	{
		//移動中だったら
		if (_isMove)
		{
			CharacterMove();
			if (!_isMove)
			{
				Managers.Item.CheckOnPlayer(transform.position);
				Managers.Turn.ChangeIsPlayerTurn();
			}
		}

		//移動中でなければ
		else
		{
			//
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
			{

			}

			//右上
			else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) &&
				Managers.Dungeon.GetMap((int)transform.position.x + 1, (int)transform.position.y + 1) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x + 1, (int)transform.position.y + 1))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x + 1, (int)transform.position.y + 1);
				StartCharacterMove(1, 1, DIR.RIGHTUP);
			}

			//右下 
			else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) &&
				Managers.Dungeon.GetMap((int)transform.position.x + 1, (int)transform.position.y - 1) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x + 1, (int)transform.position.y - 1))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x + 1, (int)transform.position.y - 1);
				StartCharacterMove(1, -1, DIR.RIGHTDOWN);
			}

			//左上
			else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) &&
				Managers.Dungeon.GetMap((int)transform.position.x - 1, (int)transform.position.y + 1) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x - 1, (int)transform.position.y + 1))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x - 1, (int)transform.position.y + 1);
				StartCharacterMove(-1, 1, DIR.LEFTUP);
			}

			//左下
			else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) &&
				Managers.Dungeon.GetMap((int)transform.position.x - 1, (int)transform.position.y - 1) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x - 1, (int)transform.position.y - 1))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x - 1, (int)transform.position.y - 1);
				StartCharacterMove(-1, -1, DIR.LEFTDOWN);
			}

			//上
			else if (Input.GetKey(KeyCode.W) &&
				Managers.Dungeon.GetMap((int)transform.position.x, (int)transform.position.y + 1) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x, (int)transform.position.y + 1))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x, (int)transform.position.y + 1);
				StartCharacterMove(0, 1, DIR.UP);
			}

			//下
			else if (Input.GetKey(KeyCode.S) &&
				Managers.Dungeon.GetMap((int)transform.position.x, (int)transform.position.y - 1) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x, (int)transform.position.y - 1))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x, (int)transform.position.y - 1);
				StartCharacterMove(0, -1, DIR.DOWN);
			}

			//右
			else if (Input.GetKey(KeyCode.D) &&
				Managers.Dungeon.GetMap((int)transform.position.x + 1, (int)transform.position.y) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x + 1, (int)transform.position.y))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x + 1, (int)transform.position.y);
				StartCharacterMove(1, 0, DIR.RIGHT);
			}

			//左
			else if (Input.GetKey(KeyCode.A) &&
				Managers.Dungeon.GetMap((int)transform.position.x - 1, (int)transform.position.y) &&
				Managers.CharacterCollider.GetCollider((int)transform.position.x - 1, (int)transform.position.y))
			{
				Managers.MiniMap.PlayerMove((int)transform.position.x, (int)transform.position.y, (int)transform.position.x - 1, (int)transform.position.y);
				StartCharacterMove(-1, 0, DIR.LEFT);
			}
		}
	}

	/// <summary>
	/// GetPosition
	/// </summary>
	/// <returns></returns>
	public Vector3 GetPosition()
	{
		return transform.position;
	}

	/// <summary>
	/// Damage
	/// </summary>
	public void Damage()
	{
		_hp--;
		_hpText.OnUpdate(_hp);

		if (_hp <= 0)
		{
			_uIWhiteController.OnAnimator("Out");
			_spriteRenderer.sprite = _damageSprite;
			Managers.Game.IsEnd = true;
		}
	}
}
