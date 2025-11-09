using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
	public InputAction escape;
	private InputAction space;
	public InputAction mouseClick;

	public static InputHandler instance;

	public ILevelInputRules levelRules;

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
		GameStateManager.instance.HandleInput();
		if (space.WasPressedThisFrame() && MapManager.instance && MapManager.currentLevelIndex != 0)
		{
			GameStateManager.instance.SwitchState(GameStateManager.levelState);
			SceneHandler.instance.LoadLevel(MapManager.currentLevelIndex);
		}
	}
}
