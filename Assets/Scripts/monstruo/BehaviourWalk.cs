using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourWalk : MonoBehaviour {
    Rigidbody rb;
    public float velocity = 1.0F;
    // Use this for initialization
    void Start () {
        //Animator anim = GetComponent<Animator>();
        //anim.Play("roar");
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float translation = Time.deltaTime * velocity;
        var nextPosition = this.transform.position += Vector3.forward * translation;
        rb.MovePosition(nextPosition);
    }

    // Update is called once per frame
    void Update()
    {
        //Animator anim = GetComponent<Animator>();
        //anim.Play("default");
        //this.transform.position += Vector3.forward * 0.2F;
    }
}
