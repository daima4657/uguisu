using UnityEngine;
using System.Collections;

public class Walk : StateMachineBehaviour {

	[SerializeField, Range(0, 3)]
	float speed = 0;

	override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		Transform transform = animator.transform;
		transform.position += transform.right * speed * Time.deltaTime;
	}
}
