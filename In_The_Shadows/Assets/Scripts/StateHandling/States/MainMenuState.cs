using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class MainMenuState : GameBaseState
{
	public override void EnterState(GameStateManager stateManager)
	{
		Debug.Log("entered main menu state");
		if (UiManager.instance.optionsMenu.activeSelf)
			UiManager.instance.ToggleOptionsMenu();
		else if (UiManager.instance.successScreen.activeSelf)
			UiManager.instance.ToggleSuccess();
	}
	public override void HandleInput(GameStateManager stateManager){}
}
