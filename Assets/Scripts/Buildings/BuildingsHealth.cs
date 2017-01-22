using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingsHealth : MonoBehaviour {


    private List<Monster> monsterTouchingThisBuilding;

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
                monsterTouchingThisBuilding[0].DestroyBuildingSound();
                Object.Destroy(this.gameObject);
            }
        }
    }

    void Start()
    {
        monsterTouchingThisBuilding = new List<Monster>();
    }


    void Update()
    {
        if (monsterTouchingThisBuilding.Count > 0)
        {
            float totalDamage = 0;
            foreach (Monster monster in monsterTouchingThisBuilding)
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

        monsterTouchingThisBuilding.Add(monster);
    }

    void OnCollisionExit(Collision other)
    {
        Monster monster = other.gameObject.GetComponent<Monster>();
        if (monster == null)
        {
            return;
        }

        monsterTouchingThisBuilding.Remove(monster);
    }
}
