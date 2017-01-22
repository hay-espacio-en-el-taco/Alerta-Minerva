using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckLost : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int buldingsLeft = FindGameObjectsWithLayer(10);
        int towersLeft = FindGameObjectsWithLayer(11);
        if (towersLeft == 0 || buldingsLeft == 0)
        {
			SceneManager.LoadScene("Game Over");
        }
    }

    int FindGameObjectsWithLayer(int layer) {
        GameObject[] goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        List<GameObject> goList = new List<GameObject>();
        for (int i = 0; i < goArray.Length; i++) {
            if (goArray[i].layer == layer) {
                goList.Add(goArray[i]);
            }
        }
        return goList.Count;
    }
}
