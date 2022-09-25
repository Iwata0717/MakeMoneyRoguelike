using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(SpawnManager))]
[RequireComponent(typeof(DungeonManager))]
[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(EnemyManager))]
[RequireComponent(typeof(TurnManager))]
[RequireComponent(typeof(MiniMapManager))]
[RequireComponent(typeof(CharacterColliderManager))]
[RequireComponent(typeof(ItemManager))]
[RequireComponent(typeof(SceneChangeManager))]

public class Managers : MonoBehaviour
{
	/// <summary>
	/// Game
	/// </summary>
	private static GameManager _gameManager;
	public static GameManager Game
	{
		get { return _gameManager; }
	}
	
	/// <summary>
	/// CharacterSpawn
	/// </summary>
	private static SpawnManager _spawnManager;
	public static SpawnManager Spawn
	{
		get { return _spawnManager; }
	}
	
	/// <summary>
	/// Dungeon
	/// </summary>
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

	/// <summary>
	/// Enemy
	/// </summary>
	private static EnemyManager _enemyManager;
	public static EnemyManager Enemy
	{
		get { return _enemyManager; }
	}

	/// <summary>
	/// Turn
	/// </summary>
	private static TurnManager _turnManager;
	public static TurnManager Turn
	{
		get { return _turnManager; }
	}

	/// <summary>
	/// MiniMap
	/// </summary>
	private static MiniMapManager _miniMapManager;
	public static MiniMapManager MiniMap
	{
		get { return _miniMapManager; }
	}

	/// <summary>
	/// CharacterCollider
	/// </summary>
	private static CharacterColliderManager _characterColliderManager;
	public static CharacterColliderManager CharacterCollider
	{
		get { return _characterColliderManager; }
	}

	/// <summary>
	/// Item
	/// </summary>
	private static ItemManager _itemManager;
	public static ItemManager Item
	{
		get { return _itemManager; }
	}

	/// <summary>
	/// Item
	/// </summary>
	private static SceneChangeManager _sceneChangeManager;
	public static SceneChangeManager SceneChange
	{
		get { return _sceneChangeManager; }
	}

	/// <summary>
	/// Awake
	/// </summary>
	private void Awake()
	{
		_gameManager = GetComponent<GameManager>();
		_spawnManager = GetComponent<SpawnManager>();
		_dungeonManager = GetComponent<DungeonManager>();
		_playerManager = GetComponent<PlayerManager>();
		_enemyManager = GetComponent<EnemyManager>();
		_turnManager = GetComponent<TurnManager>();
		_miniMapManager = GetComponent<MiniMapManager>();
		_characterColliderManager = GetComponent<CharacterColliderManager>();
		_itemManager = GetComponent<ItemManager>();
		_sceneChangeManager = GetComponent<SceneChangeManager>();
	}
}
