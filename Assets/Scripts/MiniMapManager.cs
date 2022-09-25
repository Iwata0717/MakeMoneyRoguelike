using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapManager : StatesBase
{
	private static Image[,] _mapCip = null;
	
	[SerializeField] private GameObject _miniMap = null;
	[SerializeField] private Image _mapCipPrefab = null;
	[SerializeField] private Sprite Player = null;
	[SerializeField] private Sprite Enemy = null;
	[SerializeField] private Sprite Floor = null;
	[SerializeField] private Sprite Item = null;
	[SerializeField] private Sprite Goal = null;

	/// <summary>
	/// OnStart
	/// </summary>
	public override void OnStart()
	{
		int height = Managers.Dungeon.GetMapHeight();
		int width = Managers.Dungeon.GetMapWidth();
		
		_miniMap.transform.position = new Vector3(_miniMap.transform.position.x, _miniMap.transform.position.y, _miniMap.transform.position.z);
		_mapCip = new Image[height, width];

		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				if (Managers.Dungeon.GetMap(j, i))
				{
					_mapCip[i, j] = Instantiate(_mapCipPrefab, new Vector2(j * _mapCipPrefab.rectTransform.sizeDelta.x, i * _mapCipPrefab.rectTransform.sizeDelta.y), Quaternion.identity);
					_mapCip[i, j].transform.SetParent(_miniMap.transform, false);
					_mapCip[i, j].sprite = Floor;
					_mapCip[i, j].gameObject.SetActive(false);
				}
			}
		}
	}

	/// <summary>
	/// OnUpdate
	/// </summary>
	public override void OnUpdate()
	{
		throw new System.NotImplementedException();
	}

	/// <summary>
	/// SetMiniMapPlayer
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	public void SetMiniMapPlayer(int x, int y)
	{
		if (!_mapCip[y, x].gameObject.activeSelf)
		{
			_mapCip[y, x].gameObject.SetActive(true);
		}

		_mapCip[y, x].sprite = Player;
	}

	/// <summary>
	/// SetMiniMap
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="cipType"></param>
	public void SetMiniMap(int x, int y, int cipType)
	{
		switch (cipType)
		{
			case 0:
				_mapCip[y, x].sprite = Enemy;
				break;

			case 1:
				_mapCip[y, x].sprite = Item;
				break;

			case 2:
				_mapCip[y, x].sprite = Goal;
				break;
		}

	}

	/// <summary>
	/// PlayerMove
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="afterX"></param>
	/// <param name="afterY"></param>
	public void PlayerMove(int x, int y, int afterX, int afterY)
	{
		if (!_mapCip[afterY, afterX].gameObject.activeSelf)
		{
			_mapCip[afterY, afterX].gameObject.SetActive(true);
		}

		_mapCip[y, x].sprite = Floor;
		_mapCip[afterY, afterX].sprite = Player;
	}

	/// <summary>
	/// EnemyMove
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="afterX"></param>
	/// <param name="afterY"></param>
	public void EnemyMove(int x, int y, int afterX, int afterY)
	{
		_mapCip[y, x].sprite = Floor;
		_mapCip[afterY, afterX].sprite = Enemy;
	}
}
