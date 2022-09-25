using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
	/// <summary>
	/// SceneChange
	/// </summary>
	/// <param name="str"></param>
	public void SceneChange(string str)
	{
		SceneManager.LoadScene(str);
	}
}