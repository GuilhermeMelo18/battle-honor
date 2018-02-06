using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mataParticula : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("killParticle",1,3.0f);
	}
	
	void killParticle() {

        Destroy(this.gameObject);
	}
}
