using UnityEngine;

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
}
