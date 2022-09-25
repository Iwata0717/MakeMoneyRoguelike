using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeManager : MonoBehaviour
{
	protected enum CipType
	{
		PLAYER,
		ENEMY,
		ITEM,
		WALL,
		FLOOR,
		GOAL
	}
	[SerializeField] protected CipType _type;

	/// <summary>
	/// ReturnType
	/// </summary>
	/// <returns></returns>
	public string ReturnType()
	{
		return _type.ToString();
	}
}
