using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour {

    public string transitionName;
	// Use this for initialization
	void Start () {
        
        if (transitionName == PlayerController.instance.areaTransitionName) {
            UIFade.instance.fadeFromBlack();
            PlayerController.instance.transform.position = this.transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
