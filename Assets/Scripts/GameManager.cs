using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private UIWhiteController _uIWhiteController = null;

	private bool _isEnd = false;
	public bool IsEnd
	{
		get { return _isEnd; }
		set { _isEnd = value; }
	}

	/// <summary>
	/// Start
	/// </summary>
	private void Start()
	{
		_uIWhiteController.OnAnimator("In");
		Managers.Dungeon.OnStart();
		Managers.MiniMap.OnStart();
		Managers.CharacterCollider.OnStart();
		Managers.Player.OnStart();
		Managers.Enemy.OnStart();
		Managers.Item.OnStart();
	}

	/// <summary>
	/// Update
	/// </summary>
	private void Update()
	{
		if (!IsEnd)
		{
			Managers.Player.OnUpdate();
		}

		if (!Managers.Turn.GetIsPlayerTurn())
		{
			Managers.Item.OnUpdate();
			Managers.Enemy.OnUpdate();
		}
	}
}
