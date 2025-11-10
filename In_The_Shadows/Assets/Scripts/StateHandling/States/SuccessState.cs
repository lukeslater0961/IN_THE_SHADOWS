using UnityEngine;
using UnityEngine.InputSystem;

public class SuccessState : GameBaseState 
{
	public override void EnterState(GameStateManager stateManager)
	{
		Debug.Log("entering success state");
		if (SceneHandler.instance.currentScene == "Level3")
			UiManager.instance.ToggleEndScreen(true);
		else
			UiManager.instance.ToggleSuccess(true);
	}

	public override void HandleInput(GameStateManager stateManager){}
}
