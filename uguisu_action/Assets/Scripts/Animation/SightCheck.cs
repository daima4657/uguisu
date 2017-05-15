using UnityEngine;
using System.Collections;

public class SightCheck : StateMachineBehaviour 
{
	Animator target;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		if( target == null ){
			//target = GameObject.Find("Canvas/Enemy").GetComponent<Animator>();
		}
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		//if( target.GetCurrentAnimatorStateInfo(0).IsName("Look") ){
			//animator.SetTrigger("DeadTrigger");
		//}
	}
}