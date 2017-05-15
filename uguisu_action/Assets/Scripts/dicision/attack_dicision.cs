using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_dicision : MonoBehaviour {

	GameObject refObj;

	// Use this for initialization
	void Start () {
		refObj = GameObject.Find("uguisu-player");
	}
	// Update is called once per frame
	void Update () {
		
	}

	//ふみつけ接触判定
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "enemy") {
			Player d1 = refObj.GetComponent<Player>();
			d1.StampFlag( true );
		}
	}
}
