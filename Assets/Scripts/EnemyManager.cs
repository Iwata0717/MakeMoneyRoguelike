using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : StatesBase
{
	private static int _maxEnemies = 10;
	private EnemyController[] _enemys = new EnemyController[_maxEnemies];

	[SerializeField] private GameObject _enemyPrefab = null;

	//
	public override void OnStart()
	{
		//エネミーの生成
		for (int i = 0; i < _maxEnemies; i++)
		{
			_enemys[i] = Managers.CharacterSpawn.CharacterSpawn(_enemyPrefab).GetComponent<EnemyController>();
			Managers.MiniMap.SetMiniMap((int)_enemys[i].transform.position.x, (int)_enemys[i].transform.position.y, 1);
		}
	}

	//
	public override void OnUpdate()
	{
		for (int i = 0; i < _maxEnemies; i++)
		{
			_enemys[i].MoveEnemy();
		}
		Managers.Turn.ChangeIsPlayerTurn();
	}
}
