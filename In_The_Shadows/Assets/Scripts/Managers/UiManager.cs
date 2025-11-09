using UnityEngine;

public class UiManager : MonoBehaviour
{
	public static UiManager					instance;

	[SerializeField]	Animator			saveAnimator;

	[SerializeField]	public GameObject	optionsMenu;
	[SerializeField]	public GameObject	mainMenu;
	[SerializeField]	public GameObject	successScreen;

	void Awake()
	{
		if (instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
	}

	void Start()
	{
		ToggleMainMenu();
	}

	public void ToggleMainMenu()
	{
		if (SceneHandler.instance.currentScene != "MainMenu")
			mainMenu.SetActive(false);
		else
			mainMenu.SetActive(!mainMenu.activeSelf);
	}

	public void ToggleOptionsMenu()
	{
		optionsMenu.SetActive(!optionsMenu.activeSelf);
		GameManager.instance.isInMenu = (optionsMenu.activeSelf) ? true : false;
	}

	public void ToggleSuccess()
	{
		successScreen.SetActive(!successScreen.activeSelf);
	}

	public void ToggleSaveStatus()
	{
		saveAnimator.SetTrigger("Show");
	}
}
