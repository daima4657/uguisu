using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damege_dicision : MonoBehaviour {

	GameObject refObj;

	// Use this for initialization
	void Start () {
		refObj = GameObject.Find("uguisu-player");
	}
	// Update is called once per frame
	void Update () {

	}

	//やられ接触判定
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "enemy") {
			Damege d1 = refObj.GetComponent<Damege>();
			d1.DamegeFlag( true );
		}
	}
}
