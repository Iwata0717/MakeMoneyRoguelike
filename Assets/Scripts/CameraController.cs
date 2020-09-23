using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public void MoveCamera(float x,float y)
	{
		transform.position = new Vector3(x, y, -10);
	}
}
