using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {
    public AudioSource ClickAudioSource;
    public AudioSource AlertAudioSource;
    /// <summary>
    /// Gos to scene.
    /// </summary>
    /// <param name="nameScene">name of the scena that you want to go.</param>
    public void goToScene(string nameScene){
        AlertAudioSource.Play();
        ClickAudioSource.Play();    
        SceneManager.LoadScene(nameScene);		
	}
}
