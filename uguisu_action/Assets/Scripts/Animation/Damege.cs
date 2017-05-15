using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damege : MonoBehaviour {

	bool FlashFlag = true;
	Rigidbody2D rb2d;
	Animator PlayerAnimation;
	public GameObject PlayerObject;
	public Player player;
	Coroutine FlashCoroutine;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		PlayerObject = GameObject.Find("uguisu-player");
		player = gameObject.GetComponent<Player>();
		PlayerAnimation = PlayerObject.GetComponent<Animator>();
		FlashCoroutine = StartCoroutine (Flash());//点滅用コルーチンの呼び出し
	}
	
	// Update is called once per frame
	void Update () {
		/*if((player.state == "damege")){
			StopCoroutine(Flash());
		} else {
			
		}*/
	}

	//ステートがdamegeでgroundに着地した場合の処理
	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "ground" && player.state == "damege") {
			Animator anim = GetComponent<Animator>();
			anim.SetBool ("isDamege", false);
			anim.SetBool ("isJumpUp", false);
			anim.SetBool ("isJumpDown", false);	
		}
	}

	/*やられ点滅用のIEnumerator*/
	private IEnumerator Flash()
	{
		Renderer renderer = GetComponent<Renderer>();
		while (FlashFlag) {
			for (int i=0; i<3; i++)
			{
				if (player.state == "damege") {
					renderer.enabled = !renderer.enabled;
				} else {
					renderer.enabled = true;
				}
				yield return new WaitForSeconds (0.1f); // 時間(秒)を指定して待機したい場合
				// yield return null; // 1フレーム待機したい場合
			}
		}
	}

	//やられ時ふっとび処理
	public void DamegeFlag(bool flag){
		Vector3 scale = transform.localScale;
		PlayerAnimation.SetBool("isDamege", true);
		if (scale.x == 1) {
			rb2d.velocity = transform.up * 8;
			rb2d.AddForce (Vector2.left * 300);
		} else if (scale.x == -1) {
			rb2d.velocity = transform.up * 8;
			rb2d.AddForce (Vector2.right * 300);
		}

	}
}
