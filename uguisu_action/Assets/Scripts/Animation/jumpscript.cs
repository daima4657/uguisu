using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscript : MonoBehaviour {

	Rigidbody2D rb2d;
	public float flap = 400f;
	public LayerMask mask;
	public Player player;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponent<Player>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		//Animatorコンポーネントを取得
		Animator anim = GetComponent<Animator> ();

		//変数canjumpでジャンプの可否をコントロールしている..がやや無理くり
		if (player.state == "idle" || player.state == "walk"){
			player.CanJump = true;
		}
		if (player.land){
			player.CanJump = false;
		}

		//上キーを押したらジャンプ...不具合あり
		if (Input.GetKey (KeyCode.UpArrow) && player.CanJump && !player.NowJump) {
			anim.SetBool ("isJumpUp", true);
			rb2d.velocity = transform.up * 16;
			player.NowJump = true;
		}

		//y速度が0より下なら落下ステートへ移行
		if (player.state == "jump_up") {
			if(rb2d.velocity.y < 0){
				anim.SetBool ("isJumpDown", true);
			}
		}

		//y速度が0より上なら上昇ステートへ移行
		if (player.state == "jump_down") {
			if(rb2d.velocity.y > 0){
				anim.SetBool ("isJumpDown", false);
			}
		}

		if(player.state == "land") {
			player.NowJump = false;
		}
		
	}

	void OnCollisionEnter2D (Collision2D col){ //2Dの衝突判定
		Animator anim = GetComponent<Animator> ();
		if(col.gameObject.tag == "ground" && player.jumpDown){ //groundタグのついたオブジェクトとの衝突時
			anim.SetBool ("isJumpUp", false);
			anim.SetBool ("isJumpDown", false);
			//jump = false;
			if(!player.jumpDown){
				player.NowJump = false;
			}
		}
		if(col.gameObject.tag == "ground" && player.jumpUp){ //groundタグのついたオブジェクトとの衝突時
			anim.SetBool ("isJumpUp", false);
			anim.SetBool ("isJumpDown", false);
			//jump = false;
			if(!player.jumpDown){
				player.NowJump = false;
			}
		}
	}
}
