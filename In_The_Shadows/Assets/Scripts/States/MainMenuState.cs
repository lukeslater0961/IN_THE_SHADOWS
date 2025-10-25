using UnityEngine;

public class MainMenuState : GameBaseState
{
	public override void EnterState(GameStateManager stateManager)
	{
		Debug.Log("entered main menu state");
	}
	public override void HandleEscapeInput(GameStateManager stateManager){}
}
