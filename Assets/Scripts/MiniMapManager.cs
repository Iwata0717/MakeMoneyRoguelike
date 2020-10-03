using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapManager : TypeManager
{
	private Image[,] _mapCip = null;

	[SerializeField] private GameObject _miniMap = null;
	[SerializeField] private Image _mapCipPrefab = null;
	[SerializeField] private Sprite Player = null;
	[SerializeField] private Sprite Enemy = null;
	[SerializeField] private Sprite Floor = null;
	[SerializeField] private Sprite Item = null;
	[SerializeField] private Sprite Goal = null;

	//
	public void MakeMiniMap(int mapWidth, int mapHeight)
	{
		//_miniMap.transform.Translate(0, -mapHeight, 0);
		_miniMap.transform.position = new Vector3(_miniMap.transform.position.x, _miniMap.transform.position.y, _miniMap.transform.position.z);
		_mapCip = new Image[mapHeight, mapWidth];

		for (int i = 0; i < mapHeight; i++)
		{
			for (int j = 0; j < mapWidth; j++)
			{
				_mapCip[i, j] = Instantiate(_mapCipPrefab, new Vector2(j * _mapCipPrefab.rectTransform.sizeDelta.x, i * _mapCipPrefab.rectTransform.sizeDelta.y), Quaternion.identity);
				_mapCip[i, j].transform.SetParent(_miniMap.transform, false);
				_mapCip[i, j].sprite = Floor;
				_mapCip[i, j].gameObject.SetActive(false);
			}
		}
	}

	//
	public void SetMiniMapPlayer(int x, int y)
	{
		if (!_mapCip[y, x].gameObject.activeSelf)
		{
			_mapCip[y, x].gameObject.SetActive(true);
		}

		_mapCip[y, x].sprite = Player;
	}

	//
	public void SetMiniMap(int x, int y, int cipType)
	{
		switch ((CipType)cipType)
		{
			case CipType.ENEMY:
				_mapCip[y, x].sprite = Enemy;
				break;

			case CipType.ITEM:
				_mapCip[y, x].sprite = Item;
				break;

			case CipType.GOAL:
				_mapCip[y, x].sprite = Goal;
				break;
		}

	}

	//
	public void PlayerMove(int x, int y, int afterX, int afterY)
	{
		if (!_mapCip[afterY, afterX].gameObject.activeSelf)
		{
			_mapCip[afterY, afterX].gameObject.SetActive(true);
		}

		_mapCip[y, x].sprite = Floor;
		_mapCip[afterY, afterX].sprite = Player;
	}

	//
	public void EnemyMove(int x, int y, int afterX, int afterY)
	{
		_mapCip[y, x].sprite = Floor;
		_mapCip[afterY, afterX].sprite = Enemy;
	}
}
