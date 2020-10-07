using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : StatesBase
{
	private PlayerController _player;

	[SerializeField] private GameObject _playerPrefab = null;
	
	public override void OnStart()
	{
		_player = Managers.CharacterSpawn.CharacterSpawn(_playerPrefab).GetComponent<PlayerController>();
	}

	public override void OnUpdate()
	{
		_player.PlayerMove();
	}
}
