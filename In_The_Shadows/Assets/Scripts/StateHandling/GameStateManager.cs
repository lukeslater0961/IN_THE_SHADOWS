using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public static GameStateManager instance;

	public static MainMenuState mainMenuState = new MainMenuState();
	public static MapState mapState = new MapState();
	public static LevelState levelState = new LevelState();


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

	public void HandleInput()
	{
		currentState.HandleInput(this);
	}
}
