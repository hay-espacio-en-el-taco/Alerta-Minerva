using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUserInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        isTowerBeingClicked();
    }


    private bool isTowerBeingClicked()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                OmniDirectionalTower otower = hitInfo.transform.GetComponent<OmniDirectionalTower>();
                if (otower != null)
                {
                    otower.ShouldAttack = true;
                    return true;
                }

                SingleDirectionalTower stower = hitInfo.transform.GetComponent<SingleDirectionalTower>();
                if (stower != null)
                {
                    // Some attacking code here
                    return true;
                }
            }
        }

        return false;
    }
}
