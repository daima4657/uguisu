using UnityEngine;
using System.Collections;

public class WalkSwitch : MonoBehaviour {

	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		//右へ歩く
		if (Input.GetKey(KeyCode.RightArrow)) {
			//animatorクラスにアクセスして右キーを押している間は歩きアニメを表示
			transform.position += transform.forward * 0.01f;
			animator.SetBool("isWalk", true);
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			//左キーを押している間も歩きアニメを表示
			transform.position += transform.forward * -0.01f;
			animator.SetBool("isWalk", true);
		} else {
			animator.SetBool("isWalk", false);
		}
	}
}