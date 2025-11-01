using UnityEngine;

public class LevelState : GameBaseState
{
	public override void EnterState(GameStateManager stateManager)
	{
		Debug.Log("entered level state");
	}

	public override void HandleEscapeInput(GameStateManager stateManager)
	{
		UiManager.instance.ToggleOptionsMenu();
	}
}
