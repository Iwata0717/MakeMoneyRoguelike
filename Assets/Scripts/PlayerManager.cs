using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	[SerializeField] private GameObject _playerPrefab = null;
	[SerializeField] private CharacterSpawnManager _characterSpawnManager = null;

	// Start is called before the first frame update
	void Start()
	{
		_characterSpawnManager.CharacterSpawn(_playerPrefab);
	}
}
