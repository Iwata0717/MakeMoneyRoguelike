using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : TypeManager
{
	[SerializeField] private GameObject _playerPrefab = null;
	[SerializeField] private CharacterSpawnManager _characterSpawnManager = null;
	[SerializeField] private MiniMapManager _miniMapManager = null;

	// Start is called before the first frame update
	void Start()
	{
		GameObject obj;

		obj = _characterSpawnManager.CharacterSpawn(_playerPrefab);
		_miniMapManager.SetMiniMapPlayer((int)obj.transform.position.x, (int)obj.transform.position.y);
		//_miniMapManager.SetMiniMap((int)obj.transform.position.x, (int)obj.transform.position.y, (int)_type);
	}
}
