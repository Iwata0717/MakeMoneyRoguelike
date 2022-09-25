using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWhiteController : MonoBehaviour
{
	private Animator _animator = null;

	/// <summary>
	/// Start
	/// </summary>
	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	/// <summary>
	/// OnAnimator
	/// </summary>
	/// <param name="str"></param>
	public void OnAnimator(string str)
	{
		_animator.SetTrigger(str);
	}

	/// <summary>
	/// SceneChange
	/// </summary>
	public void SceneChange()
	{
		if(Managers.Item.GetItemValue() == Managers.Item.GetMaxItem())
		{
			Managers.SceneChange.SceneChange("Ending");
		}
		else
		{
			Managers.SceneChange.SceneChange("Opning");
		}
	}
}
