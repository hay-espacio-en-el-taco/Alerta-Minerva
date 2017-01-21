using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour {

	// Use this for initialization
	Rigidbody rb = new Rigidbody();
	Vector3 v3Velocity = new Vector3();

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		v3Velocity = rb.velocity;	
	}

	void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.name == "Suelo")
        {
			if (v3Velocity.y <= -10.0f) {
				Object.Destroy(this.gameObject);
			}
        }
    }
}
