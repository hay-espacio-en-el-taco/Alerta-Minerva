using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniDirectionalTower : MonoBehaviour {
    public Collider attackObject;
    public GameObject spawnPoint;
    public float maxScale = 2;
    public float Speed = 1;
    public AudioSource waveSound;

    private GameObject currentWave = null;

    private bool _isAttacking = false;

    [SerializeField]
    private bool _shouldAttack = false;

    public bool ShouldAttack
    {
        get { return this.ShouldAttack; }
        set
        {
            if (this._shouldAttack != value)
            {
                this._shouldAttack = value;

                if (this._shouldAttack)
                {
                    this._isAttacking = true;
                }
                else
                {
                    cleanUp();
                }
            }
        }
    }


    void FixedUpdate()
    {
        if (this._isAttacking)
        {
            Attack();
        }
       
    }


    private void Attack()
    {
        if (this.currentWave != null)
        {
            this.currentWave.transform.position = this.spawnPoint.transform.position;// Sigue al objeto en caso de que vaya cayendo

            if (Mathf.Abs(this.currentWave.transform.localScale.x) > this.maxScale)
            {// Tamaño máximo alcanzado
                waveSound.Stop();
                this.ShouldAttack = false;
            }
            else
            {// Sigue creciendo
                this.currentWave.transform.localScale += -1 * Vector3.one * Time.deltaTime * this.Speed;
            }
        }
        else
        {// Instancia el ataque (objeto)
            waveSound.Play();
            this.currentWave = Instantiate(attackObject.gameObject) as GameObject;
            this.currentWave.transform.position = this.spawnPoint.transform.position;
        }
    }

    public void cleanUp()
    {
        this._isAttacking = false;
        Object.Destroy(this.currentWave);
        this.currentWave = null;
    }
}
