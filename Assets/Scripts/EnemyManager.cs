using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : StatesBase
{
	private static int _maxEnemies = 10;
	private EnemyController[] _enemys = new EnemyController[_maxEnemies];

	[SerializeField] private GameObject _enemyPrefab = null;
	[SerializeField] private GameObject _enemyFile = null;

	/// <summary>
	/// OnStart
	/// </summary>
	public override void OnStart()
	{
		//エネミーの生成
		for (int i = 0; i < _maxEnemies; i++)
		{
			_enemys[i] = Managers.Spawn.Spawn(_enemyPrefab,true).GetComponent<EnemyController>();
			_enemys[i].transform.parent = _enemyFile.transform;
			_enemys[i].Inisialize();
			Managers.MiniMap.SetMiniMap((int)_enemys[i].transform.position.x, (int)_enemys[i].transform.position.y, 1);
		}
	}

	/// <summary>
	/// OnUpdate
	/// </summary>
	public override void OnUpdate()
	{
		for (int i = 0; i < _maxEnemies; i++)
		{
			if (!_enemys[i].ChackAttackArea())
			{
				_enemys[i].MoveEnemy();
			}
		}
		Managers.Turn.ChangeIsPlayerTurn();
	}
}
