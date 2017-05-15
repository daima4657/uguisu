using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChecker : MonoBehaviour {

	Animator PlayerAnimation;
	public GameObject myObject;
	public string state = "empty";

	void Awake()
	{
		myObject = GameObject.Find("uguisu-player");
		PlayerAnimation = myObject.GetComponent<Animator>();
	}

	void Update (){
		StateGetter();
	}

	public void StateGetter(){
		AnimatorStateInfo stateInfo = PlayerAnimation.GetCurrentAnimatorStateInfo(0);
		if (stateInfo.nameHash == Animator.StringToHash("Base Layer.idle")) {
			state = "idle";
		} else if(stateInfo.nameHash == Animator.StringToHash("Base Layer.walk")){
			state = "walk";
		} else if(stateInfo.nameHash == Animator.StringToHash("Base Layer.jump_up")){
			state = "jump_up";
		} else if(stateInfo.nameHash == Animator.StringToHash("Base Layer.jump_down")){
			state = "jump_down";
		} else if(stateInfo.nameHash == Animator.StringToHash("Base Layer.land")){
			state = "land";
		} else if(stateInfo.nameHash == Animator.StringToHash("Base Layer.damege")){
			state = "damege";
		}
	}
}
