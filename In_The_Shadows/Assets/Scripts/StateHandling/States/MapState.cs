using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class MapState : GameBaseState
{
	public override void EnterState(GameStateManager stateManager)
    {
		Debug.Log("entering map state");
        stateManager.StartCoroutine(WaitForMapManager());
    }

    private IEnumerator WaitForMapManager()
    {
        while (MapManager.instance == null)
            yield return null;
		MapManager.instance.InitialiseLevelState();
    }

	public override void HandleInput(GameStateManager stateManager)
	{
		if (InputHandler.instance.escape.WasPressedThisFrame())
			UiManager.instance.ToggleOptionsMenu();
	}
}
