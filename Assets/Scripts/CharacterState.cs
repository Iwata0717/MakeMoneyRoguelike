using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
	protected int _hp;
	protected int _attack;
	protected int _defense;
	protected enum DIR
	{
		UP,
		DOWN,
		RIGHT,
		//RIGHTUP,
		//RIGHTDOWN,
		LEFT,
		//LEFTUP,
		//LEFTDOWN
	}
	protected DIR _dir;
}