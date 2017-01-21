using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour {

	private List<Monster> monsterTouchingThisTower;

    /// <summary>
    /// Vida total del edificio
    /// </summary>
    [SerializeField]
    private float health = 100;

    public float Health
    {
        get
        {
            return this.health;
        }
        private set
        {
            this.health = value;

            if (this.health <= 0)
            {
                Object.Destroy(this.gameObject);
            }
        }
    }

    void Start()
    {
        monsterTouchingThisTower = new List<Monster>();
    }


    void Update()
    {
        if (monsterTouchingThisTower.Count > 0)
        {
            float totalDamage = 50;
            foreach (Monster monster in monsterTouchingThisTower)
            {
                totalDamage += monster.Damage;
            }

            this.Health -= totalDamage * Time.deltaTime;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        Monster monster = other.gameObject.GetComponent<Monster>();
        if (monster == null)
        {
            return;
        }

        monsterTouchingThisTower.Add(monster);
    }

    void OnCollisionExit(Collision other)
    {
        Monster monster = other.gameObject.GetComponent<Monster>();
        if (monster == null)
        {
            return;
        }

        monsterTouchingThisTower.Remove(monster);
    }
}
