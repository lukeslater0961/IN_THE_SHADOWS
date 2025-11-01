using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
	private InputAction escape;
	private InputAction space;
	private InputAction mouseClick;
	public static InputHandler instance;

	private ILevelInputRules levelRules;

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
		escape = InputSystem.actions.FindAction("Escape");
		space = InputSystem.actions.FindAction("Space");
		mouseClick = InputSystem.actions.FindAction("Mouse");
		levelRules = null;
    }

    void Update()
    {
		HandleInput();
    }

	public void SetRules(ILevelInputRules rules)
	{
		levelRules = rules;
	}

	void HandleInput()
	{
		if (GameStateManager.instance.currentState !=  GameStateManager.mainMenuState && escape.WasPressedThisFrame())
			GameStateManager.instance.HandleEscapeInput();
		if (MapManager.instance && MapManager.currentLevelIndex != 0 && space.WasPressedThisFrame())
		{
			GameStateManager.instance.SwitchState(GameStateManager.levelState);
			SceneHandler.instance.LoadLevel(MapManager.currentLevelIndex);
		}//to be removed
		else if(GameStateManager.instance.currentState == GameStateManager.levelState && levelRules != null)
			levelRules.HandleLevelInput(mouseClick);
			//ShadowChecker.instance.CheckShadow();
	}
}
