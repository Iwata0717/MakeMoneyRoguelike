using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : StatesBase
{
	[SerializeField] private GameObject _itemPrefab = null;
	[SerializeField] private GameObject _itemFile = null;
	[SerializeField] private UIItemController _uIItemController = null;
	[SerializeField] private UIWhiteController _uIWhiteController = null;

	private GameObject[] _items = null;
	private int _maxItem = 10;
	private int _itemValue = 0;

	/// <summary>
	/// OnStart
	/// </summary>
	public override void OnStart()
	{
		_items = new GameObject[_maxItem];
		for (int i = 0; i < _maxItem; i++)
		{
			_items[i] = Managers.Spawn.Spawn(_itemPrefab,false);
			_items[i].transform.parent = _itemFile.transform;
		}
	}

	/// <summary>
	/// OnUpdate
	/// </summary>
	public override void OnUpdate()
	{

	}

	/// <summary>
	/// CheckOnPlayer
	/// </summary>
	/// <param name="playerPosition"></param>
	public void CheckOnPlayer(Vector3 playerPosition)
	{
		for (int i = 0; i < _maxItem; i++)
		{
			if (_items[i].activeSelf)
			{
				if (_items[i].transform.position == playerPosition)
				{
					_items[i].SetActive(false);
					_itemValue++;
					_uIItemController.OnUpdate(_itemValue);
				}
			}
		}
		if(_itemValue == _maxItem)
		{
			_uIWhiteController.OnAnimator("Out");
			Managers.Game.IsEnd = true;
		}
	}

	/// <summary>
	/// GetItemValue
	/// </summary>
	/// <returns></returns>
	public int GetItemValue()
	{
		return _itemValue;
	}

	/// <summary>
	/// GetMaxItem
	/// </summary>
	/// <returns></returns>
	public int GetMaxItem()
	{
		return _maxItem;
	}
}
