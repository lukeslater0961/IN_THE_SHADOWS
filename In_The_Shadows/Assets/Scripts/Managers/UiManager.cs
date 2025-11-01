using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class UiManager : MonoBehaviour
{
	public static UiManager instance;
	[SerializeField]	public GameObject optionsMenu;
	[SerializeField]	GameObject mainMenu;


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
		if (SceneHandler.instance.currentScene != "MainMenu"){
			mainMenu.SetActive(false);
		}
		else
			mainMenu.SetActive(!mainMenu.activeSelf);
	}

	public void ToggleOptionsMenu()
	{

		optionsMenu.SetActive(!optionsMenu.activeSelf);
		if (optionsMenu.activeSelf){
			GameManager.instance.isInMenu = true;
		}
		else
			GameManager.instance.isInMenu = false;
	}

	public void SwitchLanguage()
	{
		string currentCode = LocalizationSettings.SelectedLocale.Identifier.Code;
		switch (currentCode)
		{
			case "fr":
				Locale english = LocalizationSettings.AvailableLocales.GetLocale("en");
                LocalizationSettings.SelectedLocale = english;
				break;
			case "en":
				Locale french = LocalizationSettings.AvailableLocales.GetLocale("fr");
                LocalizationSettings.SelectedLocale = french;
				break;
            default:
				break;
		}
	}
}
