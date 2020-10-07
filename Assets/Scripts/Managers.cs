using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(CharacterSpawnManager))]
[RequireComponent(typeof(DungeonManager))]
[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(EnemyManager))]
[RequireComponent(typeof(TurnManager))]
[RequireComponent(typeof(MiniMapManager))]
[RequireComponent(typeof(CharacterColliderManager))]

public class Managers : MonoBehaviour
{
	//
	private static GameManager _gameManager;
	public static GameManager Game
	{
		get { return _gameManager; }
	}

	//
	private static CharacterSpawnManager _characterSpawnManager;
	public static CharacterSpawnManager CharacterSpawn
	{
		get { return _characterSpawnManager; }
	}

	//
	private static DungeonManager _dungeonManager;
	public static DungeonManager Dungeon
	{
		get { return _dungeonManager; }
	}

	//
	private static PlayerManager _playerManager;
	public static PlayerManager Player
	{
		get { return _playerManager; }
	}

	//
	private static EnemyManager _enemyManager;
	public static EnemyManager Enemy
	{
		get { return _enemyManager; }
	}

	//
	private static TurnManager _turnManager;
	public static TurnManager Turn
	{
		get { return _turnManager; }
	}

	//
	private static MiniMapManager _miniMapManager;
	public static MiniMapManager MiniMap
	{
		get { return _miniMapManager; }
	}

	//
	private static CharacterColliderManager _characterColliderManager;
	public static CharacterColliderManager CharacterCollider
	{
		get { return _characterColliderManager; }
	}

	private void Awake()
	{
		_gameManager = GetComponent<GameManager>();
		_characterSpawnManager = GetComponent<CharacterSpawnManager>();
		_dungeonManager = GetComponent<DungeonManager>();
		_playerManager = GetComponent<PlayerManager>();
		_enemyManager = GetComponent<EnemyManager>();
		_turnManager = GetComponent<TurnManager>();
		_miniMapManager = GetComponent<MiniMapManager>();
		_characterColliderManager = GetComponent<CharacterColliderManager>();
	}
}
