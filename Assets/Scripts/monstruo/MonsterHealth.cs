using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour {

    public const int WAVE_LAYER = 9;

    [SerializeField]
    private float _health = 100f;

    public float Heatlh
    {
        get { return this._health; }
        private set
        {
            this._health = value;
            if (_health <= 0)
            {
                GameObject.Destroy(this.gameObject);
                Score.addPoints(100);
            }
        }
    }


	void OnCollisionStay(Collision other) {

        if (other.gameObject.layer == WAVE_LAYER)
        {
            WaveDamageI towerDamageI = other.transform.GetComponent<WaveDamageI>();
            this.Heatlh -= towerDamageI.DamageAmount * Time.deltaTime;
        }
         
	}
}

