using UnityEngine;
using UnityEngine.InputSystem;

public class LevelState : GameBaseState
{
	public override void EnterState(GameStateManager stateManager)
	{
		Debug.Log("entered level state");
	}

	public override void HandleInput(GameStateManager stateManager)
	{
		if (InputHandler.instance.levelRules != null)
			InputHandler.instance.levelRules.HandleLevelInput(InputHandler.instance.mouseClick);
		if (InputHandler.instance.escape.WasPressedThisFrame())
			UiManager.instance.ToggleOptionsMenu();
	}
}
