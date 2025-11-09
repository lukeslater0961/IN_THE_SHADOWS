using UnityEngine;
using UnityEngine.InputSystem;

public class SuccessState : GameBaseState 
{
	public override void EnterState(GameStateManager stateManager)
	{
		Debug.Log("entering success state");
		UiManager.instance.ToggleSuccess(true);
	}

	public override void HandleInput(GameStateManager stateManager){}
}
