using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour {

	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {	
	}

	void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.name == "Suelo")
        {
			if (col.relativeVelocity.magnitude > 10) {
            	Object.Destroy(this.gameObject);
    		}
        }
    }
}
