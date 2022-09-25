using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	/// <summary>
	/// MoveCamera
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	public void MoveCamera(float x,float y)
	{
		transform.position = new Vector3(x, y, -10);
	}
}
