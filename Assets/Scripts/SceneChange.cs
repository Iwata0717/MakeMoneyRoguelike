using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
	[SerializeField] private string _sceneName = null;
	/// <summary>
	/// Update
	/// </summary>
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			SceneManager.LoadScene(_sceneName);
		}
	}
}
