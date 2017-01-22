using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour {
	
	public float spawnTime = 3f;            // How long between each spawn.
	public int limitMonsters = 7;			// Maximum of the monsters iin scene
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	public GameObject[] monsterTypes;       // An array of the mounter type prefab to be spawned.


	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		createMonster();
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}


	/// <summary>
	/// Create random type of monster in a random spawn point whole number of monsters are less than limitMonsters
	/// </summary>
	void Spawn ()
	{
		if(GameObject.FindGameObjectsWithTag("monster").Length < limitMonsters)
			createMonster ();
	}

	bool createMonster(){
		try{
			//Select the spawn point to create the enamy
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			//Select the mounterType to create the enamy
			int monsterTypeIndex = Random.Range (0, monsterTypes.Length);

			// Create an instance of the mounter prefab at the randomly selected spawn point's position and rotation.
			Instantiate (monsterTypes[monsterTypeIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);           
			return true;
		}
		catch{ return false; }
	}
}
