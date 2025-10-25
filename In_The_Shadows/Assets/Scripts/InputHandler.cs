using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
	private InputAction escape;
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
    }

    void Update()
    {
		HandleInput();
    }

	void HandleInput()
	{
		if (GameStateManager.instance.currentState !=  GameStateManager.mainMenuState && escape.WasPressedThisFrame())
			GameStateManager.instance.HandleEscapeInput();
	}
}
