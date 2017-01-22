using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour {

    public const int WAVE_LAYER = 9;
    public const float MIN_SCALE = 3f;

    [SerializeField]
    private float _health = 100f;

    public float Heatlh
    {
        get { return this._health; }
        private set
        {
            this._health = value;
            Vector3 currentScale = transform.localScale;
            if (_health <= 0)
            {
                GameObject.Destroy(this.gameObject);
            } else if (currentScale.x > MIN_SCALE)
            {
                Vector3 newScale = new Vector3(transform.localScale.x * (_health / 100), transform.localScale.y * (_health / 100), transform.localScale.z * (_health / 100));
                transform.localScale = new Vector3(newScale.x, newScale.y, newScale.z);
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
