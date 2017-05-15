using UnityEngine;

public class BooleanSwitchByKey : StateMachineBehaviour 
{
	[SerializeField]
	KeyCode keycode;

	[SerializeField]
	string parameterName;

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		animator.SetBool(parameterName, Input.GetKey(keycode));
	}
}