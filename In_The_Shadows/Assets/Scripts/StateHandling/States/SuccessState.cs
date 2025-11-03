using UnityEngine;

public class SuccessState : GameBaseState 
{
	public override void EnterState(GameStateManager stateManager)
	{
		Debug.Log("entering success state");
		UiManager.instance.ToggleSuccess();
	}

	public override void HandleEscapeInput(GameStateManager stateManager){}
}
