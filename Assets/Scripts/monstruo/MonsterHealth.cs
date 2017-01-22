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
            } else if (_health > 20)
            {
                Vector3 currentScale = transform.localScale;
                Vector3 newScale = new Vector3(transform.localScale.x * (_health / 100),0,0);
                Debug.Log(newScale.x);
                transform.localScale = new Vector3(newScale.x, newScale.x, newScale.x);
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
