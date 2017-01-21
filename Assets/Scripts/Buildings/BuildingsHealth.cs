﻿using UnityEngine;
using System.Collections;

public class BuildingsHealth : MonoBehaviour {

    /// <summary>
    /// Vida total del edificio
    /// </summary>
    [SerializeField]
    private float health = 100;

    public float Health
    {
        get
        {
            return this.Health;
        }
        private set
        {
            this.health = value;

            if (this.health < 0)
            {
                this.health = 0;
            }
        }
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Monster monster = other.GetComponent<Monster>();

        if (monster == null)
        {
            return;
        }

        this.health -= monster.Damage * Time.deltaTime;
    }
}
