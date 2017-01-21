using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {
	/// <summary>
	/// Gos to scene.
	/// </summary>
	/// <param name="nameScene">name of the scena that you want to go.</param>
	public void goToScene(string nameScene){		
		Application.LoadLevel(nameScene);		
	}
}
