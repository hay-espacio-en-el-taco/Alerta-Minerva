using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	float speed = 20f;
	Vector3 cameraInitialPosition = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
		cameraInitialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update()
 	{
		Quaternion rot = transform.rotation;
		if(Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(new Vector3(speed * Time.deltaTime,speed * Time.deltaTime,0));
			//transform.rotation = rot * Quaternion.Euler(0, 0, speed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(new Vector3(-speed * Time.deltaTime,-speed * Time.deltaTime,0));
			//transform.rotation = rot * Quaternion.Euler(speed * Time.deltaTime, 0, 0);
		}
		if(Input.GetKey(KeyCode.DownArrow)) {
			transform.Translate(new Vector3(speed * Time.deltaTime,-speed * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.UpArrow)) {
			transform.Translate(new Vector3(-speed * Time.deltaTime,speed * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.Space)) {
			transform.position = cameraInitialPosition;
		}
 	}
}
