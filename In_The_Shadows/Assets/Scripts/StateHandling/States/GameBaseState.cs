using UnityEngine;

public abstract class GameBaseState
{
	public abstract void EnterState(GameStateManager stateManager);
	public abstract void HandleInput(GameStateManager stateManager);
}
