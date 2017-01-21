using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour {
	
	public GameObject[] monsterTypes;       // An array of the mounter type prefab to be spawned.
	public float spawnTime = 3f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}


	/// <summary>
	/// Create random type of monster in a random spawn point 
	/// </summary>
	void Spawn ()
	{
		//Select the spawn point to create the enamy
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		//Select the mounterType to create the enamy
		int monsterTypeIndex = Random.Range (0, monsterTypes.Length);

		// Create an instance of the mounter prefab at the randomly selected spawn point's position and rotation.
		Instantiate (monsterTypes[monsterTypeIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
