using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public static GameStateManager instance;

	public static MainMenuState mainMenuState = new MainMenuState();
	public static MapState mapState = new MapState();

	public GameBaseState currentState;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
	}

    void Start()
    {
        currentState = mainMenuState;
		currentState.EnterState(this);
    }

	public void SwitchState(GameBaseState state)
	{
		currentState = state;
		currentState.EnterState(this);
	}

	public void HandleEscapeInput()
	{
		currentState.HandleEscapeInput(this);
	}
}
