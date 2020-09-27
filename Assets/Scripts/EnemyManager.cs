using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	private static int _maxEnemies = 0;
	private EnemyController[] _enemys = new EnemyController[_maxEnemies];

	[SerializeField] private GameObject _enemyPrefab = null;
	[SerializeField] private CharacterSpawnManager _characterSpawnManager = null;
	[SerializeField] private TurnManager _turnManager = null;

	// Start is called before the first frame update
	void Start()
	{
		//エネミーの生成
		for (int i = 0; i < _maxEnemies; i++)
		{
			_enemys[i] = _characterSpawnManager.CharacterSpawn(_enemyPrefab).GetComponent<EnemyController>();
		}
	}

	// Update is called once per frame
	void Update()
	{
		//
		if (!_turnManager.GetIsPlayerTurn())
		{
			for (int i = 0; i < _maxEnemies; i++)
			{
				//_enemys[i].MoveEnemy();
			}
			_turnManager.ChangeIsPlayerTurn();
		}
	}
}
