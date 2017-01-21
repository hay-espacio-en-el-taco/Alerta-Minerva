using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBehavior : MonoBehaviour {
    public Rigidbody rb;
    public float velocity = 1.0F;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float translation = Time.deltaTime * velocity;
        var nextPosition = this.transform.position += Vector3.forward * translation;
        rb.MovePosition(nextPosition);
    }
}
