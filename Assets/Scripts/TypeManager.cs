using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeManager : MonoBehaviour
{
	protected enum Type
	{
		PLAYER,
		ENEMY,
		ITEM,
		WALL,
		FLOOR
	}
	[SerializeField] protected Type _type;

	public string ReturnType()
	{
		return _type.ToString();
	}
}
