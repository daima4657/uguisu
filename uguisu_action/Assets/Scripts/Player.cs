using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//変数定義
	Rigidbody2D rb2d;
	public float flap = 400f;
	//Rigidbody2D rb2d;
	//状態管理用変数
	public string state = "empty";

	public bool NowJump = false;
	public bool CanJump = false;
	public bool CanControl = true;

	public bool idle = false;
	public bool walk = false;
	public bool jumpUp = false;
	public bool jumpDown = false;
	public bool land = false;
	public bool stamp = false;
	public bool damege = false;
	//アニメータコンポーネント用変数
	private Animator animator;

	Animator PlayerAnimation;
	public GameObject myObject;
	public float thrust;

	float d = 1f;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		myObject = GameObject.Find("uguisu-player");
		PlayerAnimation = myObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

		StateChecker StateChecker = GetComponent<StateChecker>();//statecheckerコンポーネントにアクセス
		state = StateChecker.state;//自前の変数にステートの状態を代入しておく

		//vector3を呼び出して移動の制御や向きの反転を行う
		Vector3 v = this.transform.position;
		Vector3 scale = transform.localScale;

		//animatorにアクセスして、ステートの状態によって変数をスイッチしている
		idle = (PlayerAnimation.GetCurrentAnimatorStateInfo (0).IsName ("idle") == true) ? true : false;
		walk = (PlayerAnimation.GetCurrentAnimatorStateInfo (0).IsName ("walk") == true) ? true : false;
		jumpUp = (PlayerAnimation.GetCurrentAnimatorStateInfo (0).IsName ("jump_up") == true) ? true : false;
		jumpDown = (PlayerAnimation.GetCurrentAnimatorStateInfo (0).IsName ("jump_down") == true) ? true : false;
		land = (PlayerAnimation.GetCurrentAnimatorStateInfo (0).IsName ("land") == true) ? true : false;
		damege = (PlayerAnimation.GetCurrentAnimatorStateInfo (0).IsName ("damege") == true) ? true : false;

		//左への歩き
		if (Input.GetKey(KeyCode.LeftArrow) && CanControl){
			v.x -= 0.05f;
			v.z = 0;//z軸を固定。根本的対処の必要あり
			scale.x = -1;
		}
		//右への歩き
		if (Input.GetKey(KeyCode.RightArrow) && CanControl){
			v.x += 0.05f;
			v.z = 0;
			scale.x = 1;
		}

		//上昇中でも下降中でもなければジャンプ判定をオフにする
		if (state == "idle" || state == "walk" || state == "land"){
			NowJump = false;
		}

		//特定のステートでキー操作による移動を無効化する
		if (state == "land" || state == "damege") {
			CanControl = false;
		} else {
			CanControl = true;
		}

		this.transform.position = v;
		transform.localScale = scale;
	}

	void FixedUpdate() {
	}

	//踏みつけアクション
	public void StampFlag(bool flag){
		stamp = flag;
		if (state == "jump_down") {
			rb2d.velocity = transform.up * 16;
		}
	}

}
