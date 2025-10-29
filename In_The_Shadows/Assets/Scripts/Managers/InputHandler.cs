using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
	private InputAction escape;
	private InputAction space;
	public static InputHandler instance;

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
    }

    void Update()
    {
		HandleInput();
    }

	void HandleInput()
	{
		if (GameStateManager.instance.currentState !=  GameStateManager.mainMenuState && escape.WasPressedThisFrame())
			GameStateManager.instance.HandleEscapeInput();
		if (MapManager.instance && MapManager.currentLevelIndex != 0 && space.WasPressedThisFrame())
		{
			GameStateManager.instance.SwitchState(GameStateManager.levelState);
			StartCoroutine(SceneHandler.instance.LoadScene(MapManager.currentLevelIndex));
		}//to be removed
		else if(space.WasPressedThisFrame() && GameStateManager.instance.currentState == GameStateManager.levelState)
			ShadowChecker.instance.CheckShadow();
	}
}
