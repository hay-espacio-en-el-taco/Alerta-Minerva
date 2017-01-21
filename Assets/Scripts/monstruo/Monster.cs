using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Monster : MonoBehaviour {

    /// <summary>
    /// Daño por segundo
    /// </summary>
    public float Damage = 18;
    public Transform target;
    public int moveSpeed = 30;
    public int rotationSpeed = 5;

    List<string> tags = new List<string>();

    private Transform myTransform;

    GameObject go;

    Rigidbody rg;



    void Awake()
    {
        myTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        tags.Add("edificio1");
        tags.Add("edificio2");
        tags.Add("edificio3");
        tags.Add("casa1");
        System.Random rnd = new System.Random();
        int rndTag = rnd.Next(0, 4);
        //Debug.Log(tags[rndTag]);
        go = GameObject.FindGameObjectWithTag(tags[rndTag]);
        target = go.transform;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Debug.Log(target);
        if (go == null)
        {
            System.Random rnd = new System.Random();
            int rndTag = rnd.Next(0, 4);
            go = GameObject.FindGameObjectWithTag(tags[rndTag]);
        }
        
        if(go != null)
        {
            target = go.transform;
            float distance = Vector3.Distance(target.transform.position, transform.position);

            //Debug.Log(distance);
            if (distance > 0)
            {
                Debug.DrawLine(target.position, myTransform.position, Color.red);

                //look at target/rotate
                //myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
                rg.MoveRotation(Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime));
                //move towards target
                
                rg.MovePosition(this.transform.position + myTransform.forward * moveSpeed * Time.deltaTime);
                //animation.Play("walk");

            }
        }

    }
}
