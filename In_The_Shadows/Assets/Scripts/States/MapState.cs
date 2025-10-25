using UnityEngine;
using System.Collections;

public class MapState : GameBaseState
{
	public override void EnterState(GameStateManager stateManager)
    {
        stateManager.StartCoroutine(WaitForMapManager());
    }

    private IEnumerator WaitForMapManager()
    {
        while (MapManager.instance == null)
            yield return null;
		MapManager.instance.InitialiseLevelState();
    }

	public override void HandleEscapeInput(GameStateManager stateManager)
	{
		Debug.Log("escape pressed");
	}
}
