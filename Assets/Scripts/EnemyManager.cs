using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	private EnemyController[] _enemys = new EnemyController[10];

	// Start is called before the first frame update
	void Start()
    {
		Spawn(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	//
	public void Spawn(int spawnValue)
	{

	}
}
