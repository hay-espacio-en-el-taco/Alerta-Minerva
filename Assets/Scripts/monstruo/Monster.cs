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
    public List<string> tags = new List<string>();
    private System.Random rnd = new System.Random();

    public AudioSource DestroyBuildingAudioSource;

    private Transform myTransform;

    GameObject go;

    Rigidbody rg;




    void Awake()
    {
        myTransform = transform;
    }

    public void DestroyBuildingSound()
    {
        DestroyBuildingAudioSource.Play();
    }

    // Use this for initialization
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        target = getRandomObjective().transform;
    }

    int getRandomTag()
    {
        return tags.Count > 0 ? rnd.Next(0, tags.Count - 1) : 0;
    }

    GameObject getRandomObjective()
    {
        GameObject[] gmArray = GameObject.FindGameObjectsWithTag(tags[getRandomTag()]);
        int num = rnd.Next(0, gmArray.Length - 1);
        return gmArray[num];
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (go == null)
        {
            go = getRandomObjective();
        }
        
        if(go != null)
        {
            target = go.transform;
            float distance = Vector3.Distance(target.transform.position, transform.position);

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
