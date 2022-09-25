using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : StatesBase
{
	[SerializeField] private UiHPController _hpText = null;
	[SerializeField] private UIWhiteController _uIWhiteController = null;
	[SerializeField] private GameObject _playerPrefab = null;

	private PlayerController _player;

	/// <summary>
	/// OnStart
	/// </summary>
	public override void OnStart()
	{
		_player = Managers.Spawn.Spawn(_playerPrefab,true).GetComponent<PlayerController>();
	}

	/// <summary>
	/// OnUpdate
	/// </summary>
	public override void OnUpdate()
	{
		_player.PlayerMove();
	}

	/// <summary>
	/// GetPosition
	/// </summary>
	/// <returns></returns>
	public Vector3 GetPosition()
	{
		return _player.GetPosition();
	}

	/// <summary>
	/// Damage
	/// </summary>
	public void Damage()
	{
		_player.Damage();
	}

	/// <summary>
	/// GetHpText
	/// </summary>
	/// <returns></returns>
	public UiHPController GetHpText()
	{
		return _hpText;
	}

	/// <summary>
	/// UIWhiteController
	/// </summary>
	/// <returns></returns>
	public UIWhiteController GetUIWhiteController()
	{
		return _uIWhiteController;
	}

	/// <summary>
	/// UIWhiteControllerOnAnimator
	/// </summary>
	/// <param name="str"></param>
	public void UIWhiteControllerOnAnimator(string str)
	{
		_uIWhiteController.OnAnimator(str);
	}
}
